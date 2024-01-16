# VolvoCars.net
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

Simple C# wrappers for the Volvo Cars Apis. See: <https://developer.volvocars.com/apis/>.

## Getting Started

Firstly you will need a Volvo developer account which can be created here: <https://developer.volvocars.com/>
This gives you access to the Api documentation and the development sandbox which includes a demo vehicle.
To run the integration tests, it is necessary to generate an access token for each Api, either for the demo vehicle or for your own vehicle linked to your developer account.

### Generating Api Access Tokens

1. Once you have a Volvo developer account set up, you can generate test access tokens here: <https://developer.volvocars.com/apis/docs/test-access-tokens/>. 

### Local Development Configuration

Each Api project in the solution has a corresponding integration test project with its own local configuration file.

1. Make a copy of the `AppSettings.IntegrationTest.json.template` file and rename it as `AppSettings.IntegrationTest.json`.
1. Set the "Copy to Output Directory" setting for this file to "Copy if newer".
1. Edit the configuration values in this file to set your development VCC Api Key.

Notice how the `AppSettings.IntegrationTest.json` file is set to be ignored by git source control. It is vital not to commit any application configuration to the source code repository.