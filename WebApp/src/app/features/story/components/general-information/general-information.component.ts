import { Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { GeneralInformation } from '../../models/story';
import { Category } from '../../models/category';
import { CategoryService } from 'src/app/shared/services/category.service';

@Component({
  selector: 'literado-general-information',
  templateUrl: './general-information.component.html',
  styleUrls: ['./general-information.component.scss']
})
export class GeneralInformationComponent implements OnInit {
  @ViewChild("inputLoader") inputLoader?: ElementRef<HTMLInputElement>;
  @ViewChild("imgLoader") imgLoader?: ElementRef<HTMLImageElement>;
  @Output() imgChange?: EventEmitter<any>;
  @Output() generalInformationForm: EventEmitter<any> = new EventEmitter<any>;
  @Input() generalInfoForm?: any;
  @Input() imgFile: any;
  categories: Category[] = []


  constructor(
    private categoryService: CategoryService
  ) {}

  ngOnInit(): void {
    this.categoryService.get().subscribe(res => {
      this.categories = res;
    });
  }

  ngAfterViewInit(): void {
    if(this.imgFile && this.imgLoader?.nativeElement) {
      const imgLoader = this.imgLoader?.nativeElement;
      const src = URL.createObjectURL(this.imgFile);
      imgLoader.src = src;
    }
  }

  openFileExplorer(): void {
    this.inputLoader?.nativeElement?.click();
  }

  showPreview(evt: any): void {
    const imgLoader = this.imgLoader?.nativeElement || null;
    if(evt.target.files.length > 0 && imgLoader){
      const src = URL.createObjectURL(evt.target.files[0]);
      this.imgFile = {
        file: evt.target.files[0],
        url: src
      } 
      imgLoader.src = src;
    }
  }

  onSubmit(): void {
    if(this.generalInfoForm && this.generalInfoForm.valid) {
      const category = this.categories.find(c => c.id === this.generalInfoForm.value.category);
      this.generalInformationForm?.emit({
        data: this.generalInfoForm.value as unknown as GeneralInformation,
        category: category?.name,
        img: this.imgFile
      })
    }
  }
}
