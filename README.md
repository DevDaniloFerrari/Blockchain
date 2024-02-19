## Blockchain Proof of Concept (POC) Project

In this project, I developed a POC of blockchain to simulate a money transaction between two individuals and record it on a blockchain.

### Technologies Used:
- C# with .NET 8
- SQL Server 2022
- RabbitMQ
- Firebase
- EntityFrameworkCore 8

### Deployment and Dependencies Management:
I utilized Docker to run the application and Docker Compose to manage all dependencies.

### Deployment on Google Cloud Platform:
I deployed the project on the Google Cloud Platform using the following services:

- **Cloud Run:** Hosted the API
- **Cloud Build:** Used for continuous integration (CI) and integrated continuous deployment (CD)
- **Google Cloud SQL:** Instance of SqlServer
- **Artifact Registry:** Used for storing Docker images during the testing period

