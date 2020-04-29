# Solution templates for Easify

[![Build status](https://ci.appveyor.com/api/projects/status/4119u1859aauex0k?svg=true)](https://ci.appveyor.com/project/moattarwork/easify-templates) ![](https://img.shields.io/nuget/v/Easify.Templates.svg?style=flat-square)

The repository contains the template to generate different solution for based on Easify framework. The template generates the required structure for WebAPI based solution using dotnet cli

## Installation

To install the template for the dotnet command line use the following command:

`dotnet new --install "Easify.API::*"`

it will add the template in list of available template for cli.

### Usage

To generate a sample solution such as Sample.API use the following command:

`dotnet new easify-api -n "Sample.API"`
