[![Build Status](https://travis-ci.org/mishani0x0ef/Project.Hub.svg?branch=master)](https://travis-ci.org/mishani0x0ef/Project.Hub)

# Project.Hub
Simple project that allow to describe useful links and downloads for your project using configuration file.

[☛EXAMPLE SITE☚](http://projecthub-env.us-east-2.elasticbeanstalk.com/)

## Setup

_Project.Hub_ is a web application that could be hosted on any hosting environment which is supported by [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/).

To setup website do next steps:

1. Navigate to [latest release](https://github.com/mishani0x0ef/Project.Hub/releases/latest).
2. Download archive with deliverables - _project.hub_x.x.zip_ (it contains build of web app).
3. Unpack  _project.hub_x.x.zip_.
4. Change _hub.config.json_ file by describing your project's links ([config description](https://github.com/mishani0x0ef/Project.Hub#configuration))
5. Configure environment according to [Microsoft guides](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/?tabs=aspnetcore2x) (supported _IIS, Windows Service, Nginx, Apache, Azure_ and other).

_NOTE: last step depends on hosting environment. Current article doesn't describe specific environment setup. Read Microsoft guides if you are not familiar with .NET Core deployment._

## Configuration

Site content of _Project.Hub_ configurable over [hub.config.json](https://github.com/mishani0x0ef/Project.Hub/blob/master/src/Project.Hub/hub.config.json) file which has next structure:

````
{
  "SystemLinks": [
    {
      "Name": "GitHub",
      "Description": "Link to project's GitHub.",
      "Url": "https://github.com/mishani0x0ef/Project.Hub",
      "ShowFavicon": true
    }
  ],
  "Environments": [
    {
      "Name": "Testing",
      "Description": "Testing environment.",

      "Sites": [
        {
          "Name": "GitHub link",
          "Description": "Could be link on any website. Click cause redirect.",
          "Url": "https://github.com"
        }
      ],

      "Downloads": [
        {
          "Name": "Download by link",
          "Description": "Download file using web link to this file.",
          "DownloadPath": "http://che.org.il/wp-content/uploads/2016/12/pdf-sample.pdf"
        }
      ],

      "Services": [
        {
          "Name": "Web Service (API) link",
          "Description": "Link any services and APIs used by your system.",
          "Url": "https://developer.github.com/v3/"
        }
      ]
    }
  ]
}
````

#### System Links

Collection of general links (git repository, issue tracker, build server, wiki etc.)

| Member | Type | Description |
|--|--|--|
| Name | (required) _string_ | Short display name of a link. |
| Url | (required) _string_ | Absolute URI to website that represented. |
| Description | (optional) _string_ | Textual description with details about a link. |
| ShowFavicon | (optional) _boolean_ | Define is site's favicon should be shown near a link name (could improve UX). |

### Environments

Collection of environment descriptions (Testing, Staging, Production etc.). Could be used as hub for link to your products.

| Member | Type | Description |
|--|--|--|
| Name | (required) _string_ | Short display name of an environment. |
| Description | (optional) _string_ | Textual description with details about an environment. |
| Sites | (optional) [_SystemLink_](https://github.com/mishani0x0ef/Project.Hub#system-links) | Collection of environment-specific links to **websites** |
| Downloads | (optional) [_DownloadLink_](https://github.com/mishani0x0ef/Project.Hub#download-link) | Collection of environment-specific download links of different files (installers, tools, any other files) |
| Services | (optional) [_SystemLink_](https://github.com/mishani0x0ef/Project.Hub#system-links) | Collection of environment-specific links to **web services** (APIs) |

### Download Link

Type that describe link to file for download.

| Member | Type | Description |
|--|--|--|
| Name | (required) _string_ | Short display name of file. |
| DownloadPath| (required) _string_ | URL to file or path in file system. <ul><li>Network shares supported</li><li>Supported version serch patterns (e.g _"d:\\builds\\Android\\app-v-*.*.*.apk"_)</li></ul> |
| Description | (optional) _string_ | Textual description with details about a file. |
| Mode | (optional) _"Direct"_ (default) \| _"FileSystem"_ | Download mode to use. <ul><li>Direct - when download by redirect to web-link</li><li>FileSystem - when download of actual file from disk or network share required.</li></ul> |
| Type | (optional) _"Application"_ (default) \| _"RemoteDesktop"_ | Type of download link. User _RemoteDesktop_ if file is remote connection configuration file (quite specific case). |

_Notes:_

_When use FileSystem download Mode make sure that web application has access to file you want to share._

_When used version search pattern like "*.*.*" in download file path hub will get latest version._
