import { Component } from '@angular/core';
import { GeneralInformation } from '../../models/story';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'literado-create-story',
  templateUrl: './create-story.page.html',
  styleUrls: ['./create-story.page.scss']
})
export class CreateStoryPage {

  constructor(private fb: FormBuilder) {}

  tab: "information" | "detail" | "review" = "information"
  createStoryForm = this.fb.group({
    general: this.fb.group({
      title: ["", Validators.required],
      category: ["", Validators.required],
      description: [""],
    }),
    detail: this.fb.group({}),
  });;

  tabChange(tab:"information" | "detail" | "review" ): void {
    this.tab = tab;
  }

  goToDetail(generalInformation: GeneralInformation) {
    console.log(generalInformation)
    const currentValue = { ...this.createStoryForm.value };
    if (currentValue.general && this.createStoryForm.get("general")) {
      currentValue.general.title = generalInformation.title;
      currentValue.general.category = generalInformation.category;
      currentValue.general.description = generalInformation.title;

      this.createStoryForm.get("general")?.patchValue(generalInformation);
    }

    this.tab = "detail";
  }

  onSubmit(): void {
    console.log(this.createStoryForm.valid, this.createStoryForm.value)
  }
}
