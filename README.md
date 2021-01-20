# Solution templates for Easify

![Release build on master/main](https://github.com/icgam/Easify.Templates/workflows/Release%20build%20on%20master/main/badge.svg) ![CI on Branches and PRs](https://github.com/icgam/Easify.Templates/workflows/CI%20on%20Branches%20and%20PRs/badge.svg)  ![](https://img.shields.io/nuget/v/Easify.API.svg?style=flat-square)

The repository contains the template to generate different solution for based on Easify framework. The template generates the required structure for WebAPI based solution using dotnet cli

## Installation

To install the template for the dotnet command line use the following command:

`dotnet new --install "Easify.API::*"`

it will add the template in list of available template for cli.

### Usage

To generate a sample solution such as Sample.API use the following command:

`dotnet new easify-api -n "Sample.API"`
