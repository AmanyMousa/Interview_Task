🔧 Back-End Setup Instructions (.NET Core API)
Follow the steps below to set up and run the back-end project:

1. Clone the Repository
git clone https://github.com/AmanyMousa/Interview_Task.git

2. Open the Back-End Project
Navigate to the back-end project folder (e.g., employee-backend) and open the solution in Visual Studio.

3. Configure appsettings.json
Open the appsettings.json file and update the DefaultConnection string with your SQL Server instance name.
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=YourDatabaseName;Trusted_Connection=True;"
}
🔁 Replace YOUR_SERVER_NAME with your local SQL Server name.

4. Apply Migrations
In Visual Studio, open the Package Manager Console from:
Tools > NuGet Package Manager > Package Manager Console
Run the following command to apply the database migrations:
Update-Database

5. Run the API
Once the database is updated, press F5 or click Start to run the API.


********To run the front-end project, follow these steps after the back-end is up and running:

1. Navigate to the Front-End Project
Go to the employee-frontend folder where the Angular project is located.

2. Install Dependencies
Run the following command to install the required Angular dependencie
npm install

3. Start the Front-End
Run the following command to start the Angular development server:
npm start

🔁 Make sure the back-end API is running at the same time, as the front-end will make requests to it.
Once the front-end is up, the app should be accessible at http://localhost:4200.






