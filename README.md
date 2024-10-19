![image](https://github.com/user-attachments/assets/bf84f5c0-24c1-4b7f-a553-6779d9e929ff)

# ResumeXfer

This project provides a Windows Forms application that allows for file uploads with resume functionality. The application is designed to upload a file from the local system to a specified remote directory, supporting interrupted transfers by resuming from where it left off.

## Features

- File Upload with Resume: The application supports resuming an interrupted file upload by appending to the existing remote file.
- Progress Tracking: Displays a progress bar and detailed upload statistics, including the upload speed and total bytes transferred.
- Disconnection Handling: Automatically retries the upload after a connection loss, ensuring that the process can continue without user intervention.
- Simple UI: Browse and select the local file and remote directory through the provided UI, and start the upload with a single button click.

## Requirements

- .NET Framework: The project is built using the .NET Framework, so you need to have the appropriate version installed on your system.
- Windows OS: This is a Windows Forms application, and thus requires a Windows operating system.

## Getting Started

1. **Clone the Repository**:
   git clone https://github.com/Sixtyneer/ResumeXfer.git

3. **Open the Project**:
   Open the solution file (ResumeXfer.sln) in Visual Studio.

4. **Build the Solution**:
   Build the solution using Visual Studio to restore any necessary packages and compile the project.
   
## How to Use

  - Select the Local File: Click on the "Browse Local File" button to select the file you wish to upload.
  - Select the Remote Folder: Click on the "Browse Remote Folder" button to choose the destination folder where the file will be uploaded.
  - Upload the File: Once both paths are selected, click the "Upload" button. The progress bar will start filling up, showing the current progress of the upload. You will also see the upload speed and the total number of bytes uploaded.
  - Handling Disconnections: If the connection is lost during the upload, the application will automatically retry after a 5-second delay and continue from where it left off.


## Known Issues

  - Large File Handling: Ensure that the remote file system supports the size of the files you are uploading.
  - UI Performance: Frequent UI updates may affect performance on slower systems.


## License

  This project is licensed under the MIT License. See the LICENSE file for more details. 

## Contributions are welcome! 
  Please open an issue or submit a pull request for any bugs or improvements.
 
