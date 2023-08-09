import { Component } from '@angular/core';
import { Detail, GeneralInformation } from '../../models/story';
import { FormBuilder, Validators } from '@angular/forms';
import { StoryService } from '../../services/story.service';
import { AlertService } from 'src/app/core/services/alert.service';
import { Router } from '@angular/router';

@Component({
  selector: 'literado-create-story',
  templateUrl: './create-story.page.html',
  styleUrls: ['./create-story.page.scss']
})
export class CreateStoryPage {

  constructor(
    private fb: FormBuilder, 
    private storyService: StoryService, 
    private alertService: AlertService,
    private router: Router) {}

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
      currentValue.detail.mature = detail.mature;
      currentValue.detail.tags = detail.tags;

      this.createStoryForm.get("general")?.patchValue(currentValue);
    }

    this.tab = "review";
  }


  onSubmit(): void {
    const data = new FormData();
    const userId = 0;
    data.append("asset", this.generalInformation.img.file, this.generalInformation.img.file.name);
    data.append("story", JSON.stringify({
      userId: userId,
      literaryGenreId: this.createStoryForm.value.general?.category,
      title: this.createStoryForm.value.general?.title,
      description: this.createStoryForm.value.general?.description,
      cover: "",
      publishedDate: null,
      rating: null,
      reads: null,
      copyrightType: null,
      tags: this.createStoryForm.value.detail?.tags,
      tagetAudience: this.createStoryForm.value.detail?.audience,
      language: this.createStoryForm.value.detail?.language,
      hasAdultContent: this.createStoryForm.value.detail?.mature,
    }));

    this.storyService.createStory(data).subscribe(data => {
      this.alertService.ModalNotification("Excelente!", "Historia creada correctamente", "success").then(() => {
        this.router.navigateByUrl("story");
      });
    });
  }
}
