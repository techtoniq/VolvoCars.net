# VolvoCars.net
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

## Getting Started

### Api Access

1. Once you have a Volvo developer account set up, you can generate test access tokens here: <https://developer.volvocars.com/apis/docs/test-access-tokens/>. 

### Local Development Configuration

1. Make a copy of the `AppSettings.IntegrationTest.json.template` file and rename it as `AppSettings.IntegrationTest.json`.
1. Set the "Copy to Output Directory" setting for this file to "Copy if newer".
1. Edit the configuration values in this file to set your development VCC Api Key.

Notice how the `AppSettings.IntegrationTest.json` file is set to be ignored by git source control. It is vital not to commit any application configuration to the source code repository.