[![Build Status](https://travis-ci.org/mishani0x0ef/Project.Hub.svg?branch=master)](https://travis-ci.org/mishani0x0ef/Project.Hub)
[![CodeFactor](https://www.codefactor.io/repository/github/mishani0x0ef/project.hub/badge)](https://www.codefactor.io/repository/github/mishani0x0ef/project.hub)

# Project.Hub
A web-based application that allows you to describe useful links and downloads for your project and have nice visual representation for them.

<p align="center">
  <img width="600" height="385" src="https://github.com/mishani0x0ef/Project.Hub/blob/master/resources/demo.gif">
</p>

## Setup

`Project.Hub` is a web application that can be hosted on any hosting environment which is supported by [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/).

To setup the website you need:

1. Navigate to the [latest release](https://github.com/mishani0x0ef/Project.Hub/releases/latest).
2. Download an archive with deliverables - `project.hub_x.x.zip`.
3. Unpack the archive.
4. Change `hub.config.json` file according to your needs ([config description](https://github.com/mishani0x0ef/Project.Hub#configuration))
5. Deploy according to [Microsoft Guides](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/?tabs=aspnetcore2x).

> NOTE: last step depends on the hosting environment. Current article doesn't describe specific environment setup. Please read Microsoft guides if you are not familiar with .NET Core deployment.

## Configuration

You can configure the content of the website using [hub.config.json](https://github.com/mishani0x0ef/Project.Hub/blob/master/src/Project.Hub/hub.config.json) file:

````json
{
  "Version": "2.0",

  "CommonServices": [
    {
      "Name": "GitHub",
      "Description": "Link to the project on the GitHub.",
      "Url": "https://github.com/mishani0x0ef/Project.Hub"
    }
  ],

  "Environments": [
    {
      "Name": "Testing",
      "Description": "Testing environment for QA engineers."
    }
  ],

  "Websites": [
    {
      "Name": "Our awesome website",
      "Description": "Could be a link to any website.",
      "Tags": [ "useful", "frontend-team" ],
      "Environments": [
        { "Environment": "Testing", "Url": "https://qa.example.com" }
      ]
    }
  ],

  "Apis": [
    {
      "Name": "Project API",
      "Description": "Could be link to any API (Swagger would be nice).",
      "Tags": [ "security", "backend-team" ],
      "Environments": [
        { "Environment": "Testing", "Url": "https://qa.example.com/api/swagger" }
      ]
    }
  ],

  "Downloads": [
    {
      "Name": "Desktop Application",
      "Description": "Download file using web-link to this file.",
      "Tags": [ "desktop", "security" ],
      "Environments": [
        { "Environment": "Testing", "DownloadPath": "https://qa.example.com/downloads/app" }
      ]
    }
  ]

}
````

#### CommonServices

List of general links (git repository, issue tracker, build server, wiki etc.)

| Member | Type | Description |
|--|--|--|
| Name | (required) _string_ | Short display name. |
| Url | (required) _string_ | Absolute URI to website. |
| Description | (optional) _string_ | Textual description with details about a link. |
| FaviconFallback| (optional) _string_ | URL to website's favicon which would be used if favicon cannot be resolved automatically. |

### Environments

List of environment descriptions (e.g. Testing, Staging, Production).

| Member | Type | Description |
|--|--|--|
| Name | (required) _string_ | Short display name of an environment. |
| Description | (optional) _string_ | Textual description with details about an environment. |

### Websites

List of websites that available on multiple environments.

| Member | Type | Description |
|--|--|--|
| Name | (required) _string_ | Short display name of a website. |
| Description | (optional) _string_ | Textual description with details about a website. |
| Tags | (optional) _string[]_ | List of hashtags to mark website with. |
| Environments | (required) _Environment[]_ | Describe path to website on different environments. See below. |
| Environment.Name | (required) _string_ | Name of the environment from [_Environments_](https://github.com/mishani0x0ef/Project.Hub#environments). |
| Environment.Url | (required) _string_ | URL to a website on particular environment. |

### APIs

List of APIs that available on multiple environments.

| Member | Type | Description |
|--|--|--|
| Name | (required) _string_ | Short display name of an API. |
| Description | (optional) _string_ | Textual description with details about an API. |
| Tags | (optional) _string[]_ | List of hashtags to mark API with. |
| Environments | (required) _Environment[]_ | Describe path to API on different environments. See below. |
| Environment.Name | (required) _string_ | Name of the environment from [_Environments_](https://github.com/mishani0x0ef/Project.Hub#environments). |
| Environment.Url | (required) _string_ | URL to an API on particular environment. |

### Downloads

List of downloads that available on multiple environments.

| Member | Type | Description |
|--|--|--|
| Name | (required) _string_ | Short display name of a file. |
| Description | (optional) _string_ | Textual description with details about a file. |
| Tags | (optional) _string[]_ | List of hashtags to mark download with. |
| Mode | (optional) _"Direct"_ (default) \| _"FileSystem"_ | Download mode: <ul><li>Direct - download using web-link</li><li>FileSystem - download file from disk or network share.</li></ul> |
| Type | (optional) _"Application"_ (default) \| _"RemoteDesktop"_ | Type of download. User _RemoteDesktop_ if file is remote connection configuration file. |
| Environments | (required) _Environment[]_ | Describe path to download on different environments. See below. |
| Environment.Name | (required) _string_ | Name of the environment from [_Environments_](https://github.com/mishani0x0ef/Project.Hub#environments). |
| Environment.DownloadPath| (required) _string_ | URL to a file or path in the file system (network shares supported; supported search patterns like `d:\\builds\\app-v-*.*.*.apk`). |

> NOTE: When using `FileSystem` make sure that Project.Hub has access to the file.

> NOTE: When `DownloadPath` using search pattern like `*.*.*` will be resolved latest version.
