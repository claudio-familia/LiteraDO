import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { StoryService } from '../../services/story.service';
import { CategoryService } from 'src/app/shared/services/category.service';
import { Category } from '../../models/category';
import { FormBuilder, Validators } from '@angular/forms';
import { AlertService } from 'src/app/core/services/alert.service';

@Component({
  selector: 'literado-detail',
  templateUrl: './detail.page.html',
  styleUrls: ['./detail.page.scss']
})
export class DetailPage implements AfterViewInit, OnInit {

  @ViewChild(MatPaginator) paginator: any;
  @ViewChild("inputLoader") inputLoader?: ElementRef<HTMLInputElement>;
  @ViewChild("imgLoader") imgLoader?: ElementRef<HTMLImageElement>;
  @ViewChild('tagInput') tagInput?: ElementRef<HTMLInputElement>;
  
  categories: Category[] = []
  chapterDisplayedColumns: string[] = ['name', 'lines'];
  chapterDataSource = new MatTableDataSource<any>([]);
  storyForm = this.fb.group({
    title: ["", Validators.required],
    category: ["", Validators.required],
    description: [""],
    language: [""],
    audience: [""],
    tags: [""],
    mature: [false]
  });
  imgFile: any;
  selectedTags: string = '';
  cover: any;
  storyId: any;
  reads: number = 0;
  reviews: number = 0;
  state: string = 'Borrador';
  publishedDate: string = 'Jueves 10, Agosto 2023';

  constructor(
    private storyService: StoryService, 
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private alertService: AlertService,
    private categoryService: CategoryService,
    private fb: FormBuilder 
  ) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((param: Params) => {
      const id = param['id']
      this.storyId = id;
      this.storyService.getById(id).subscribe(data => {
        this.chapterDataSource.data = data.chapters;
        this.cover = data.cover;
        this.state = data.state;
        this.reads = data.reads;
        this.reviews = data.rating;
        this.storyForm.setValue({
          audience: data.tagetAudience,
          category: data.literaryGenreId,
          description: data.description,
          language: data.language,
          mature: data.hasAdultContent,
          tags: "",
          title: data.title
        });
        this.selectedTags = data.tags;
        if(data.cover) {
          this.imgLoader!.nativeElement.src = this.cover;
        }
        console.log(this.storyForm)
      })
    })
    this.categoryService.get().subscribe(res => {
      this.categories = res;
    });
  }

  enableForm(): boolean {
    return !(this.storyForm.valid && this.storyForm.dirty && this.storyForm.touched);
  }

  ngAfterViewInit() {
    this.chapterDataSource.paginator = this.paginator;
    if(this.cover) {
      this.imgLoader!.nativeElement.src = this.cover;
    }
  }

  viewChapter(row: any) {
    this.router.navigateByUrl(`/story/detail/${this.storyId}/chapter/${row.id}`)
  }

  openFileExplorer(): void {
    this.inputLoader?.nativeElement?.click();
  }

  showPreview(evt: any): void {
    const imgLoader = this.imgLoader?.nativeElement || null;
    if(evt.target.files.length > 0 && imgLoader){
      const src = URL.createObjectURL(evt.target.files[0]);
      this.imgFile = evt.target.files[0];
      imgLoader.src = src;
      this.storyForm.markAsDirty();
      this.storyForm.markAsTouched();
    }
  }

  addTag(evt: any) {
    const value = evt.value;
    const array = this.selectedTags.split(',');
    array.push(value);
    this.selectedTags = array.filter(v => v).join();
    this.tagInput!.nativeElement.value = "";
  }

  deleteTag(tag: string): void {
    const array = this.selectedTags.split(',');
    this.selectedTags = array.filter(v => v !== tag).join();
  }

  publish(): void {
    this.alertService.ModalNotification('¿Está seguro que deseas publicar tu historia?', 'Esta a punto de hacer tu historia visible para todos nuestros lectores', 'question', 'No, mejor lo hare mas tarde')
    .then(res => {
        if (res.isConfirmed) {
          this.storyService.publishStory(this.storyId).subscribe(response => {
            console.log(response)
            this.alertService.ModalNotification("Excelente!", "Tu historia ha sido publicada correctamente", "success").then(() => {
              window.location.reload();
            });
          });
        }
    });
  }

  onSubmit(): void {
    if(this.storyForm && this.storyForm.valid) {
      const data = this.storyForm.value;
      data.tags = this.selectedTags;
      console.log(data)
      const formData = new FormData();
      if (this.imgFile) {
        formData.append("asset", this.imgFile, this.imgFile.name);
      } else {
        formData.append("asset", "");
      }
      
      formData.append("story", JSON.stringify({
        id: Number(this.storyId),
        literaryGenreId: data.category,
        title: data.title,
        description: data.description,
        tags: data.tags,
        tagetAudience: data.audience,
        language: data.language,
        hasAdultContent: data.mature,
      }));
  
      this.storyService.updateStory(formData).subscribe(response => {
        this.alertService.ModalNotification("Excelente!", "Historia actualizada correctamente", "success").then(() => {
          window.location.reload();
        });
      });
    }
  }
}
