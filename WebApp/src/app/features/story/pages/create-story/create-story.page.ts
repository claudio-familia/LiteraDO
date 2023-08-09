import { Component } from '@angular/core';
import { Detail, GeneralInformation } from '../../models/story';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'literado-create-story',
  templateUrl: './create-story.page.html',
  styleUrls: ['./create-story.page.scss']
})
export class CreateStoryPage {

  constructor(private fb: FormBuilder) {}

  tab: "information" | "detail" | "review" = "information"
  generalInformation: any;
  createStoryForm = this.fb.group({
    general: this.fb.group({
      title: ["", Validators.required],
      category: ["", Validators.required],
      description: [""],
    }),
    detail: this.fb.group(
      {
        language: [""],
        audience: [""],
        tags: ["", Validators.required],
        mature: [false]
      }
    ),
  });

  tabChange(tab:"information" | "detail" | "review" ): void {
    this.tab = tab;
  }

  goToDetail(generalInformation: {data: GeneralInformation, img: any}) {
    const currentValue = { ...this.createStoryForm.value } as any;
    if (currentValue.general && this.createStoryForm.get("general")) {
      currentValue.general.title = generalInformation.data.title;
      currentValue.general.category = generalInformation.data.category;
      currentValue.general.description = generalInformation.data.description;
      this.generalInformation = generalInformation;
      this.createStoryForm.get("general")?.patchValue(currentValue);
    }

    this.tab = "detail";
  }

  goToReview(detail: Detail) {
    const currentValue = { ...this.createStoryForm.value } as any;
    if (currentValue.detail && this.createStoryForm.get("detail")) {
      currentValue.detail.audience = detail.audience;
      currentValue.detail.language = detail.language;
      currentValue.detail.matureContent = detail.matureContent;
      currentValue.detail.tags = detail.tags;

      this.createStoryForm.get("general")?.patchValue(currentValue);
    }

    this.tab = "review";
  }


  onSubmit(): void {
    console.log(this.createStoryForm.valid, this.createStoryForm.value)
  }
}
