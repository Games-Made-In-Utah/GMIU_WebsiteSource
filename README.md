# IGDA Games Made in Utah Website

## Overview

This project is the IGDA Games Made in Utah website, built with ASP.NET Core MVC and deployed on Netlify. It features community-driven content about indie games developed in Utah and provides users with event information and resources for local game developers.

## Features

- **Event Scraping**: Automatically fetches and displays upcoming events from IGDA.
- **Responsive Design**: Optimized for both desktop and mobile devices.
- **Custom Styles**: Includes custom styling using a color palette, animations, and hover effects.
  
## Requirements

- .NET SDK (6.0 LTS or later)
- Visual Studio or VSCode (with C# support)
- Node.js (if any frontend dependencies are needed)
- A Netlify account for deployment

## Folder Structure

Ensure the following files and folders are included in the output folder before deploying:

- **Views/Converted HTML**: Make sure all `.cshtml` views are converted to `.html` files. 
- **Static Assets**: Include `wwwroot/` for all static assets such as images, CSS, and JavaScript files.
- **Events Scraper Code**: The backend scraping functionality should be included as well.
- **Site CSS**: Ensure the custom `site.css` is updated based on the new color palette and layout modifications.

## Setup Instructions

### Step 1: Clone the Repository

1. Clone the project repository from GitHub:

   ```bash
   git clone https://github.com/YourUsername/IGDA-Games-Made-In-Utah.git
   cd IGDA-Games-Made-In-Utah
   ```

### Step 2: Configure the Project

1. Ensure your `EventsController.cs`, `HomeController.cs`, and `EventScraper` logic are correctly implemented. Follow the structure we’ve defined earlier.
2. Add all converted views to the `Views` folder, making sure they are `.html` files instead of `.cshtml`.
3. If you haven't already, include the `wwwroot/` directory for any static files (CSS, JS, Images).

### Step 3: Build the Project Locally

1. If you're running the ASP.NET Core project locally, build it using the following:

   ```bash
   dotnet build
   dotnet run
   ```

### Step 4: Prepare for Deployment to Netlify

1. **Ensure All Files Are in the Output Folder**: The following need to be present in the output folder:
   - All `.html` files converted from `.cshtml`.
   - `wwwroot` for all static assets (CSS, images, etc.).
   - Necessary configurations for the site.
   
2. **Add a `_redirects` File (Optional)**: If your project uses routing and you need to handle any redirects, create a `_redirects` file and place it in the root of your output folder.

### Step 5: Deploy to Netlify

1. Go to [Netlify](https://netlify.app) and sign in or create an account.
2. Create a new site by clicking the “New Site from Git” button.
3. Select your GitHub repository where the project is stored.
4. In the **Build Settings**:
   - Build command: None (or `npm run build` if using Node for any frontend work).
   - Publish directory: Point to your output folder containing the converted `.html` files and the `wwwroot/` directory.

5. Click "Deploy Site" and wait for the process to complete.

### Step 6: Verify Deployment

Once deployed, navigate to your Netlify URL (which will be provided during deployment) to verify that the website is functioning correctly, including:

- Proper rendering of events.
- Fully responsive navigation and design.
- Links working as expected.

### Optional Step: Add Custom Domain

1. In your Netlify dashboard, go to **Domain settings**.
2. Add a custom domain if you have one and follow the DNS instructions provided.

## Credits

- Project by Trevor Hicks (IGDA Utah)
- Event scraping logic based on the `IGDA.org` events page.
  
## Contact

If you encounter issues or have questions about setup or contributions, feel free to open an issue or reach out.

