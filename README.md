# Games Made in Utah Website

## Overview

This project is the Games Made in Utah website, originally built with ASP.NET Core MVC and deployed on Netlify. It features numerous games made locally in Utah, gaming events within Salt Lake City and groups to connect with other gamers or game developers.

&nbsp;
## Features

- **Responsive Design**: Optimized for both desktop and mobile devices.
- **Custom Styles**: Includes custom styling using a color palette, animations, and hover effects.

&nbsp;
## Requirements

- VSCode
- A Netlify account for deployment

&nbsp;
## Setup Instructions

### Step 1: Clone the Repository

1. Clone the project repository from GitHub:

   ```bash
   git clone https://github.com/Games-Made-In-Utah/GMIU_WebsiteSource.git
   ```

### Step 2: Open Source Folder/Workspace in VSCode

Open the cloned source folder (Games Made In Utah) or the code workspace file in VSCode.

### (Optional) Step 3: Install Live Server Extension

Download the "Live Server" extension by Ritwick Dey from the VSCode tab (Ctrl+Shift+X).

- Right click the index.html file to "Open with Live Server" (Alt+L+O) and view the website.

&nbsp;
## Adding Games to Collection

New games can be easily added to the site's collection by editing the data/game_list.json file and adding a new entry (see below).

```
{
    "title": "[Game Title]",
    "developer": "[Developer/Team]",
    "description": "[Short Description of Game]",
    "image": "[Preview Image]",
    "imageAlt": "[Preview Image Alt Text]",
    "link": "[Relevant Link (Store Page, Developer Website, etc.)]",
    "tags": ["Put", "Tags", "Here"]
}
```
> [!NOTE]
> Tags determine what games will show up when filtering the collection.

&nbsp;
## Deploying to Netlify

### Step 1: Navigate to Netlify

Go to your Netlify's Account Dashboard and open the "sites" tab

### Step 2: Create/Update Site

To create a new site:

- Click the "Add new site" button, select the "deploy manually" option and select the cloned source folder. 

To update a created site:

- Navigate to the bottom of your selected site's deploys, click "browse to upload" and select the cloned source folder.

### Step 3: Verify Deployment

Once deployed, navigate to your new deployment and click preview to verify that the website is functioning correctly, including:

- Proper rendering of events.
- Fully responsive navigation and design.
- Links working as expected.

### Step 4: Publish Deployment

Once verified, return to the new deployment and click publish to update the live website with your new deployment. 

&nbsp;
## Credits

- Project Creation by Trevor Hicks (IGDA Utah) @-2024
- Updates/Refactoring by Landon Stevens & Dakota Partney (IGDA Utah) @-2025

&nbsp;
## Contact

If you encounter issues or have questions about setup or contributions, feel free to open an issue or reach out.
