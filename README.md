# Blockchain Proof of Concept (POC) Project

In this project, I developed a POC of blockchain to simulate a money transaction between two individuals and record it on a blockchain.

## Technologies Used:
- C# with .NET 8
- SQL Server 2022
- RabbitMQ
- Firebase
- Entity Framework Core 8
- xUnit
- Moq
- JWT

## Development Tools:
- Docker: Used to run the application
- Docker Compose: Managed all dependencies
- GitHub Actions: Used as CI for building and testing

## Deployment on Google Cloud Platform:
I deployed the project on the Google Cloud Platform using the following services:

- **Cloud Run:** Hosted the API
- **Cloud Build:** Used for continuous integration (CI) and integrated continuous deployment (CD)
- **Google Cloud SQL:** Instance of SqlServer
- **Artifact Registry:** Used for storing Docker images during the testing period

![Blockchain-Project Architecture drawio](https://github.com/DevDaniloFerrari/Blockchain/assets/40414119/14c3045a-e467-499c-a69f-af16184bb3f0)

![Blockchain-CI CD Flow drawio](https://github.com/DevDaniloFerrari/Blockchain/assets/40414119/779a5d0c-7afd-408e-a7d8-625393c5e2c7)
