import { OnInit, Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AlertService } from 'src/app/core/services/alert.service';
import { ActivatedRoute, Router } from '@angular/router';
import { StoryChapterService } from '../../services/story-chapter.service';

@Component({
  selector: 'literado-create-chapter',
  templateUrl: './create-chapter.page.html',
  styleUrls: ['./create-chapter.page.scss']
})
export class CreateChapterPage implements OnInit {
  chapterForm = this.fb.group({
    title: ["", Validators.required],
    description: ["", Validators.required]
  });

  showTopButton: boolean = false;
  storyId: string = "";
  title: string = "";
  chapter: string = "Nuevo capitulo";
  chapterId: string = "";

  constructor(
    private fb: FormBuilder, 
    private storyChapterService: StoryChapterService, 
    private alertService: AlertService,
    private router: Router,
    private activatedRoute: ActivatedRoute) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.storyId = params['id'];
      this.chapterId = params['chapterId'];
      this.storyChapterService.getStoryName(this.storyId).subscribe((response: any) => {
        this.title = response.title;
      })
      if(this.chapterId) {
        this.chapter = `Capitulo id: ${this.chapterId}`;
        this.storyChapterService.getById(this.chapterId).subscribe((response: any) => {
          this.chapterForm.setValue({
            title: response.name,
            description: response.description
          });
        });
      }
    })
  }

  goBack(): void {
    this.router.navigateByUrl(`story/detail/${this.storyId}`);
  }

  onSubmit(): void {
    console.log(this.chapterForm.valid, this.chapterForm.value)
    if(this.chapterForm.valid) {
      const data = {
        storyId: this.storyId,
        name: this.chapterForm.value.title,
        description: this.chapterForm.value.description,
      };
      if(this.chapterId) {
        const updatePayload = {
          id: this.chapterId,
          ...data
        }
        this.storyChapterService.update(updatePayload).subscribe((data: any) => {
          this.alertService.ModalNotification("Excelente!", "Capitulo actualizado correctamente", "success").then(() => {
            console.log(data)
            this.router.navigateByUrl(`story/detail/${this.storyId}`);
          });
        });
      }else {
        this.storyChapterService.create(data).subscribe((data: any) => {
          this.alertService.ModalNotification("Excelente!", "Capitulo creado correctamente", "success").then(() => {
            console.log(data)
            this.router.navigateByUrl(`story/detail/${this.storyId}`);
          });
        });
      }
    }
  }
}
