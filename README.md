# Assessment Projects Repository

This repository contains multiple C#/.NET-based assessment projects developed as part of the evaluation process. Each project is organized into its respective folder and demonstrates different programming concepts and real-world application scenarios.

## 📁 Folder Structure

- **GeneralAssessment1/**
  - Contains C# console-based programs focused on basic logic, loops, file handling, and number series like Fibonacci.
  
- **GeneralAssessment2/**
  - Includes additional C# programs covering problem-solving tasks and foundational coding exercises.

- **OpenSenseMapAssessment/**
  - A complete ASP.NET Core Web API application integrating with [OpenSenseMap REST APIs](https://docs.opensensemap.org/).
  - Features:
    - User Registration and Login (Token-based Authentication)
    - Create SenseBox
    - Retrieve SenseBox by ID
    - Logout Functionality
    - Swagger UI documentation for testing endpoints

- **zip-projects/**
  - Contains zipped versions of the above projects for easy download and review.

## 🛠️ How to Run

1. Clone the repository.
2. Open the solution in Visual Studio.
3. Set the desired project (e.g., `OpenSenseMapAssessment`) as the Startup Project.
4. Run the project and test the APIs using Swagger UI or Postman.

## 🛠️ General Assessments Setup    

- Both GeneralAssessment1 and GeneralAssessment2 projects are included under a single solution. To run any of the general assessment programs:
1. Open the solution in Visual Studio.
2. Right-click on the project you want to run and select "Set as Startup Project".
3. Build and run the application. 

## ✅ Notes

- Make sure to restore NuGet packages before building the solution.
- Error handling have been implemented in the OpenSenseMap assessment.
- Swagger UI provides interactive documentation for testing API endpoints.
