# Blockchain Proof of Concept (POC) Project

In this project, I developed a POC of blockchain to simulate a money transaction between two individuals and record it on a blockchain.

## Technologies Used:
- C# with .NET 8
- SQL Server 2022
- RabbitMQ
- Firebase
- EntityFrameworkCore 8
- xUnit
- Moq

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

![Blockchain drawio](https://github.com/DevDaniloFerrari/Blockchain/assets/40414119/fa04e1af-ed3d-420b-91f2-f10335a5ea91)

![Blockchain-CD Flow drawio](https://github.com/DevDaniloFerrari/Blockchain/assets/40414119/f67d70e3-34fc-47e6-b3e5-53b2e823bb39)
