import { Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { GeneralInformation } from '../../models/story';

@Component({
  selector: 'literado-general-information',
  templateUrl: './general-information.component.html',
  styleUrls: ['./general-information.component.scss']
})
export class GeneralInformationComponent implements OnInit {
  @ViewChild("inputLoader") inputLoader?: ElementRef<HTMLInputElement>;
  @ViewChild("imgLoader") imgLoader?: ElementRef<HTMLImageElement>;
  @Output() imgChange?: EventEmitter<any>;
  @Output() generalInformationForm: EventEmitter<GeneralInformation> = new EventEmitter<GeneralInformation>;
  @Input() generalInfoForm?: any;

  constructor(
    private fb: FormBuilder,
  ) {}

  ngOnInit(): void {
    console.log('Method not implemented.');
  }

  openFileExplorer(): void {
    this.inputLoader?.nativeElement?.click();
  }

  showPreview(evt: any): void {
    const imgLoader = this.imgLoader?.nativeElement || null;
    if(evt.target.files.length > 0 && imgLoader){
      const src = URL.createObjectURL(evt.target.files[0]);
      console.log(src, imgLoader)
      imgLoader.src = src;
    }
  }

  onSubmit(): void {
    if(this.generalInfoForm && this.generalInfoForm.valid) {
      this.generalInformationForm?.emit(this.generalInfoForm.value as unknown as GeneralInformation)
    }
  }
}
