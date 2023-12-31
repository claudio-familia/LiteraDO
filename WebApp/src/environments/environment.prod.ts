// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
    production: true,
    ApiUrl: 'https://literado-api.azurewebsites.net/api/',
    authenticateUsers: true,
    urls: {
      users: "users",
      auth: "authentication",
      country: "countries",
      category: "literaryGenres",
      story: "stories",
      storyChapter: "storyChapters"
    }
  };
