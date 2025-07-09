# Step 4: Find Production Deployment Before Cutoff Date

**Plan**: 20250709-061905-6a8ce1c3
**Status**: Completed
**Started**: 2025-07-09T06:19:11Z
**Completed**: 2025-07-09T06:19:17Z
**Duration**: 6.78 seconds

## Goal
Identify the most recent pull request merged to the production branch before July 1, 2025.

## Prompt
Get pull requests for the production branch in the 'dotnet-helix-service' repository filtered by closed date before 2025-07-01, ordered by creation date descending.

## Execution Details

## Response
- **Server**: azure-devops-primary
- **Tool**: get_pull_requests_by_closed_date
- **Results**:
```
{
  "TotalCount": 101,
  "FilteredBy": {
    "Status": "completed",
    "TargetBranch": "refs/heads/main",
    "TimeRangeType": "closed",
    "BeforeClosedDate": "2025-07-01 00:00:00",
    "AfterClosedDate": null,
    "MaxResults": null
  },
  "PullRequests": [
    {
      "PullRequestId": 51170,
      "Title": "A11y fixes for banner landmark",
      "Status": 3,
      "CreationDate": "2025-06-25T22:22:21.3719358Z",
      "ClosedDate": "2025-06-26T21:10:01.55478Z",
      "SourceRefName": "refs/heads/missymessa-7877",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
        "Name": "Missy Messa",
        "Email": "mjanecke@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "f0c34267-aedb-6a23-8361-271e79fc9284",
          "Name": "Tomas Weinfurt",
          "Vote": 0
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 51079,
      "Title": "[main] Update dependencies from dotnet/dnceng",
      "Status": 3,
      "CreationDate": "2025-06-20T02:01:52.7923941Z",
      "ClosedDate": "2025-06-20T21:39:28.5070141Z",
      "SourceRefName": "refs/heads/darc-main-0936e357-3e68-4f96-b5ef-4aaa9acaaa2c",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "c81111e3-e146-69f1-b0a6-dd3ca4dde3a0",
        "Name": "ProductConstructionServiceProd",
        "Email": "72f988bf-86f1-41af-91ab-2d7cd011db47\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
          "Name": "Missy Messa",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 50933,
      "Title": "Remove Kusto SAS reference",
      "Status": 3,
      "CreationDate": "2025-06-16T22:22:08.2524857Z",
      "ClosedDate": "2025-06-18T23:01:11.6018651Z",
      "SourceRefName": "refs/heads/removeKusto",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "02bcc5bb-1d50-66e4-9b9f-736c0b1329e7",
        "Name": "Epsitha Ananth",
        "Email": "epananth@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
          "Name": "Missy Messa",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 50794,
      "Title": "Fix missing images in Build Analysis checks",
      "Status": 3,
      "CreationDate": "2025-06-12T10:37:02.0639165Z",
      "ClosedDate": "2025-06-12T16:10:51.9518503Z",
      "SourceRefName": "refs/heads/dev/alkpli/images",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "abd4b441-4b86-457c-a2d9-e09243ccd846",
        "Name": "Alexander K\u00F6plinger",
        "Email": "alkpli@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
          "Name": "Missy Messa",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 50697,
      "Title": "[main] Update dependencies from dotnet/dnceng-shared",
      "Status": 3,
      "CreationDate": "2025-06-07T02:01:09.277749Z",
      "ClosedDate": "2025-06-18T05:38:03.8992942Z",
      "SourceRefName": "refs/heads/darc-main-f1df5d2d-38d8-4da1-b262-9526fbb86732",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "c81111e3-e146-69f1-b0a6-dd3ca4dde3a0",
        "Name": "ProductConstructionServiceProd",
        "Email": "72f988bf-86f1-41af-91ab-2d7cd011db47\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 50691,
      "Title": "Refactor Helix Service to use AwesomeAssertions 9.0.0",
      "Status": 3,
      "CreationDate": "2025-06-06T16:28:01.6786592Z",
      "ClosedDate": "2025-06-06T18:45:44.8118992Z",
      "SourceRefName": "refs/heads/missymessa-5408",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
        "Name": "Missy Messa",
        "Email": "mjanecke@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "db0724ea-305e-418a-969c-779e49c58ad8",
          "Name": "David Foster (DEVOPS)",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 50688,
      "Title": "Merge back production -\u003E main 06-06-2025",
      "Status": 3,
      "CreationDate": "2025-06-06T16:15:40.375998Z",
      "ClosedDate": "2025-06-06T16:39:56.934887Z",
      "SourceRefName": "refs/heads/production",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "db0724ea-305e-418a-969c-779e49c58ad8",
        "Name": "David Foster (DEVOPS)",
        "Email": "davfost@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "f0c34267-aedb-6a23-8361-271e79fc9284",
          "Name": "Tomas Weinfurt",
          "Vote": 10
        },
        {
          "Id": "db0724ea-305e-418a-969c-779e49c58ad8",
          "Name": "David Foster (DEVOPS)",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 50640,
      "Title": "Update deployment steps to be a \u0022release\u0022 job",
      "Status": 3,
      "CreationDate": "2025-06-04T21:38:28.4782363Z",
      "ClosedDate": "2025-06-30T18:22:06.304234Z",
      "SourceRefName": "refs/heads/dev/chcosta/refactor-release",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "da8e23bb-3123-4efe-9074-87b88acf60b7",
        "Name": "Christopher Costa",
        "Email": "chcosta@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 50605,
      "Title": "Refactor EventHub in Helix Service to use modern Azure SDK",
      "Status": 3,
      "CreationDate": "2025-06-03T22:55:48.0565253Z",
      "ClosedDate": "2025-06-13T20:41:15.6244576Z",
      "SourceRefName": "refs/heads/missymessa-893",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
        "Name": "Missy Messa",
        "Email": "mjanecke@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 50532,
      "Title": "[main] Update dependencies from dotnet/dnceng",
      "Status": 3,
      "CreationDate": "2025-06-01T02:01:42.794294Z",
      "ClosedDate": "2025-06-04T14:22:25.9775097Z",
      "SourceRefName": "refs/heads/darc-main-064daa12-c6d5-4af9-984f-b55b36d1370d",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "c81111e3-e146-69f1-b0a6-dd3ca4dde3a0",
        "Name": "ProductConstructionServiceProd",
        "Email": "72f988bf-86f1-41af-91ab-2d7cd011db47\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
          "Name": "Missy Messa",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 50520,
      "Title": "[main] Update dependencies from dotnet/dnceng-shared",
      "Status": 3,
      "CreationDate": "2025-05-31T02:02:05.8997475Z",
      "ClosedDate": "2025-06-05T19:28:34.4872958Z",
      "SourceRefName": "refs/heads/darc-main-54aec916-b41f-470d-9a32-3dac1d7d0b31",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "c81111e3-e146-69f1-b0a6-dd3ca4dde3a0",
        "Name": "ProductConstructionServiceProd",
        "Email": "72f988bf-86f1-41af-91ab-2d7cd011db47\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
          "Name": "Missy Messa",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 50412,
      "Title": "Add TimeProvider singleton for GitHubAppTokenProvider DI change in Microsoft....",
      "Status": 3,
      "CreationDate": "2025-05-27T17:37:35.1648798Z",
      "ClosedDate": "2025-05-27T22:59:54.6132404Z",
      "SourceRefName": "refs/heads/dev/chcosta/timeprovider-update",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "da8e23bb-3123-4efe-9074-87b88acf60b7",
        "Name": "Christopher Costa",
        "Email": "chcosta@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
          "Name": "Missy Messa",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 50394,
      "Title": "Update Dnceng team members.",
      "Status": 3,
      "CreationDate": "2025-05-26T12:17:27.1842241Z",
      "ClosedDate": "2025-05-27T16:53:53.0099128Z",
      "SourceRefName": "refs/heads/dev/ondrejsmid/update-dncengteam-members",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "a8ab78a9-2d24-67a5-8426-61435ee7fb35",
        "Name": "Ondrej Smid",
        "Email": "ondrejsmid@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
          "Name": "Missy Messa",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 50301,
      "Title": "Refactored Helix Service to use Azure.Messaging.Service instead of Microsoft.Azure.ServiceBus",
      "Status": 3,
      "CreationDate": "2025-05-21T22:36:20.6015957Z",
      "ClosedDate": "2025-06-02T15:17:52.7673921Z",
      "SourceRefName": "refs/heads/missymessa-refactor-servicebus-libs",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
        "Name": "Missy Messa",
        "Email": "mjanecke@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "db0724ea-305e-418a-969c-779e49c58ad8",
          "Name": "David Foster (DEVOPS)",
          "Vote": 0
        },
        {
          "Id": "da8e23bb-3123-4efe-9074-87b88acf60b7",
          "Name": "Christopher Costa",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 50228,
      "Title": "[main] Update dependencies from dotnet/dnceng",
      "Status": 3,
      "CreationDate": "2025-05-20T02:02:08.8576677Z",
      "ClosedDate": "2025-05-28T15:02:13.9773006Z",
      "SourceRefName": "refs/heads/darc-main-b8f45194-9b8d-4fbd-bdcb-a10962bc497c",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "c81111e3-e146-69f1-b0a6-dd3ca4dde3a0",
        "Name": "ProductConstructionServiceProd",
        "Email": "72f988bf-86f1-41af-91ab-2d7cd011db47\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
          "Name": "Missy Messa",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 50221,
      "Title": "Remove unused namespaces",
      "Status": 3,
      "CreationDate": "2025-05-20T00:07:07.2843314Z",
      "ClosedDate": "2025-05-20T00:34:50.0213297Z",
      "SourceRefName": "refs/heads/missymessa-888",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
        "Name": "Missy Messa",
        "Email": "mjanecke@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 50210,
      "Title": "Removed unused variables",
      "Status": 3,
      "CreationDate": "2025-05-19T23:07:05.6846678Z",
      "ClosedDate": "2025-05-19T23:38:08.8599568Z",
      "SourceRefName": "refs/heads/missymessa-887",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
        "Name": "Missy Messa",
        "Email": "mjanecke@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 50132,
      "Title": "Merge back production -\u003E main 05-16-2025",
      "Status": 3,
      "CreationDate": "2025-05-16T16:24:00.6987162Z",
      "ClosedDate": "2025-05-16T17:04:34.4224333Z",
      "SourceRefName": "refs/heads/production",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "db0724ea-305e-418a-969c-779e49c58ad8",
        "Name": "David Foster (DEVOPS)",
        "Email": "davfost@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "db0724ea-305e-418a-969c-779e49c58ad8",
          "Name": "David Foster (DEVOPS)",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 50088,
      "Title": "Remove former teammates\u0027 aliases from Startup.Auth.cs",
      "Status": 3,
      "CreationDate": "2025-05-15T20:52:09.9700697Z",
      "ClosedDate": "2025-05-16T22:32:51.0194763Z",
      "SourceRefName": "refs/heads/missymessa-remove-former-teammates",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
        "Name": "Missy Messa",
        "Email": "mjanecke@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "4954a309-db5f-67cc-af54-0f1695d4e970",
          "Name": "Juan Sebastian Hoyos Ayala",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        },
        {
          "Id": "11d4085b-6535-6a6c-a5ef-c87bedeca35e",
          "Name": "Meghna Verma",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 49940,
      "Title": "Return azure storage links from listfiles API",
      "Status": 3,
      "CreationDate": "2025-05-09T16:40:22.6396076Z",
      "ClosedDate": "2025-05-09T18:02:08.4775139Z",
      "SourceRefName": "refs/heads/dev/janielsen/listfiles-azure-urls",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "69178761-8b3b-61ec-99bb-adddbae2c7d3",
        "Name": "Jakob Botsch Nielsen",
        "Email": "janielsen@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "02bcc5bb-1d50-66e4-9b9f-736c0b1329e7",
          "Name": "Epsitha Ananth",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 49870,
      "Title": "[main] Update dependencies from dotnet/dnceng-shared",
      "Status": 3,
      "CreationDate": "2025-05-08T02:01:51.4631398Z",
      "ClosedDate": "2025-05-19T22:04:01.6617426Z",
      "SourceRefName": "refs/heads/darc-main-4a7d0498-b0ff-4014-bee7-211a19b7d337",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "c81111e3-e146-69f1-b0a6-dd3ca4dde3a0",
        "Name": "ProductConstructionServiceProd",
        "Email": "72f988bf-86f1-41af-91ab-2d7cd011db47\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "b1f55bb3-0f83-65fa-8753-6f328b94345e",
          "Name": "Haruna Ogweda",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 0
        }
      ]
    },
    {
      "PullRequestId": 49821,
      "Title": "[main] Update dependencies from dotnet/dnceng",
      "Status": 3,
      "CreationDate": "2025-05-07T02:01:32.5976291Z",
      "ClosedDate": "2025-05-16T22:33:38.1911325Z",
      "SourceRefName": "refs/heads/darc-main-b41dc460-4e9c-457a-85aa-4dc74a7684e9",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "c81111e3-e146-69f1-b0a6-dd3ca4dde3a0",
        "Name": "ProductConstructionServiceProd",
        "Email": "72f988bf-86f1-41af-91ab-2d7cd011db47\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 49817,
      "Title": "Update YAML to use .NET 8",
      "Status": 3,
      "CreationDate": "2025-05-06T21:31:00.5763498Z",
      "ClosedDate": "2025-05-07T17:42:25.1494838Z",
      "SourceRefName": "refs/heads/missymessa-2412",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
        "Name": "Missy Messa",
        "Email": "mjanecke@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "a84ff60a-5a35-4c3f-8bb9-2e40b21f88b6",
          "Name": "Doug Bunting",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 49811,
      "Title": "Switch user delegation SAS to use HelixStorageHelper._isExternal",
      "Status": 3,
      "CreationDate": "2025-05-06T16:10:30.1754256Z",
      "ClosedDate": "2025-05-06T20:03:16.7611772Z",
      "SourceRefName": "refs/heads/dev/janielsen/no-sas-public",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "69178761-8b3b-61ec-99bb-adddbae2c7d3",
        "Name": "Jakob Botsch Nielsen",
        "Email": "janielsen@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
          "Name": "Missy Messa",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 49727,
      "Title": "Remove old admins",
      "Status": 3,
      "CreationDate": "2025-05-04T18:31:17.5815119Z",
      "ClosedDate": "2025-05-05T16:16:41.8249007Z",
      "SourceRefName": "refs/heads/dougbu/quick.admin.cleanup.5534",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "a84ff60a-5a35-4c3f-8bb9-2e40b21f88b6",
        "Name": "Doug Bunting",
        "Email": "dougbu@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "0994e4e4-d484-4337-a745-54d4db413c14",
          "Name": "Ilya Skuratovsky",
          "Vote": 10
        },
        {
          "Id": "749f5e71-0fb3-48e1-bcbf-a0b61c8bc426",
          "Name": "[TEAM FOUNDATION]\\.NET Product Construction Services",
          "Vote": 0
        }
      ]
    },
    {
      "PullRequestId": 49690,
      "Title": "Upgrade to use .NET 8",
      "Status": 3,
      "CreationDate": "2025-05-01T23:07:10.8641574Z",
      "ClosedDate": "2025-05-06T15:12:11.7158588Z",
      "SourceRefName": "refs/heads/missymessa-upgrade-to-.net8",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
        "Name": "Missy Messa",
        "Email": "mjanecke@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 49689,
      "Title": "Remove uses of local auth in staging",
      "Status": 3,
      "CreationDate": "2025-05-01T21:59:10.9646041Z",
      "ClosedDate": "2025-05-02T22:13:36.1141827Z",
      "SourceRefName": "refs/heads/dev/janielsen/no-job-sas",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "69178761-8b3b-61ec-99bb-adddbae2c7d3",
        "Name": "Jakob Botsch Nielsen",
        "Email": "janielsen@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "4954a309-db5f-67cc-af54-0f1695d4e970",
          "Name": "Juan Sebastian Hoyos Ayala",
          "Vote": 10
        },
        {
          "Id": "f0c34267-aedb-6a23-8361-271e79fc9284",
          "Name": "Tomas Weinfurt",
          "Vote": 10
        },
        {
          "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
          "Name": "Missy Messa",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 49685,
      "Title": "add queue name to list of machines without heartbeat",
      "Status": 3,
      "CreationDate": "2025-05-01T19:24:09.5522958Z",
      "ClosedDate": "2025-05-20T16:33:15.9355767Z",
      "SourceRefName": "refs/heads/wfurt/qName",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "f0c34267-aedb-6a23-8361-271e79fc9284",
        "Name": "Tomas Weinfurt",
        "Email": "toweinfu@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 49643,
      "Title": "Updated WorkItem File permalink to account for null/missing logs",
      "Status": 3,
      "CreationDate": "2025-04-30T07:51:16.7860042Z",
      "ClosedDate": "2025-05-01T18:47:13.5165894Z",
      "SourceRefName": "refs/heads/juhoyosa/null-check",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "4954a309-db5f-67cc-af54-0f1695d4e970",
        "Name": "Juan Sebastian Hoyos Ayala",
        "Email": "juhoyosa@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
          "Name": "Missy Messa",
          "Vote": 10
        },
        {
          "Id": "69178761-8b3b-61ec-99bb-adddbae2c7d3",
          "Name": "Jakob Botsch Nielsen",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 49625,
      "Title": "Handle /console properly for both static files and internal files",
      "Status": 3,
      "CreationDate": "2025-04-29T19:11:23.7410918Z",
      "ClosedDate": "2025-05-01T16:26:22.9845389Z",
      "SourceRefName": "refs/heads/dev/janielsen/console-log-try-3",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "69178761-8b3b-61ec-99bb-adddbae2c7d3",
        "Name": "Jakob Botsch Nielsen",
        "Email": "janielsen@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
          "Name": "Missy Messa",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 49590,
      "Title": "Handle Console API for statically hosted files too",
      "Status": 3,
      "CreationDate": "2025-04-29T09:37:14.6697629Z",
      "ClosedDate": "2025-04-29T14:53:39.3396069Z",
      "SourceRefName": "refs/heads/dev/janielsen/console-log-cancelled",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "69178761-8b3b-61ec-99bb-adddbae2c7d3",
        "Name": "Jakob Botsch Nielsen",
        "Email": "janielsen@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "9e5742ee-d918-4543-99a1-616b44d67b54",
          "Name": "Ricardo Arenas",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 49547,
      "Title": "Skip permalinks for files from dotnet.github.io",
      "Status": 3,
      "CreationDate": "2025-04-28T10:05:09.7171247Z",
      "ClosedDate": "2025-04-28T15:17:34.4248214Z",
      "SourceRefName": "refs/heads/dev/janielsen/static-file-results",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "69178761-8b3b-61ec-99bb-adddbae2c7d3",
        "Name": "Jakob Botsch Nielsen",
        "Email": "janielsen@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
          "Name": "Missy Messa",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 49411,
      "Title": "Return \u0022file permalinks\u0022 for authenticated files from HelixAPI",
      "Status": 3,
      "CreationDate": "2025-04-23T14:16:12.9247452Z",
      "ClosedDate": "2025-04-24T18:09:59.8616783Z",
      "SourceRefName": "refs/heads/dev/janielsen/file-permalinks",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "69178761-8b3b-61ec-99bb-adddbae2c7d3",
        "Name": "Jakob Botsch Nielsen",
        "Email": "janielsen@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "9e5742ee-d918-4543-99a1-616b44d67b54",
          "Name": "Ricardo Arenas",
          "Vote": 10
        },
        {
          "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
          "Name": "Missy Messa",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 49395,
      "Title": "Do not truncate text on overflow",
      "Status": 3,
      "CreationDate": "2025-04-22T23:31:03.6207663Z",
      "ClosedDate": "2025-04-22T23:54:11.0299812Z",
      "SourceRefName": "refs/heads/mistucke/6585-queueinfo-a11y-minimum-fix",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
        "Name": "Michael Stuckey",
        "Email": "mistucke@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
          "Name": "Missy Messa",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 49333,
      "Title": "Remove Kusto SAS from settings.json",
      "Status": 3,
      "CreationDate": "2025-04-18T23:40:39.2505344Z",
      "ClosedDate": "2025-04-19T01:20:17.9955354Z",
      "SourceRefName": "refs/heads/clean-up",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "02bcc5bb-1d50-66e4-9b9f-736c0b1329e7",
        "Name": "Epsitha Ananth",
        "Email": "epananth@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "a84ff60a-5a35-4c3f-8bb9-2e40b21f88b6",
          "Name": "Doug Bunting",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 49247,
      "Title": "Remove SAS from Metrics Observer",
      "Status": 3,
      "CreationDate": "2025-04-16T18:21:11.0168024Z",
      "ClosedDate": "2025-04-18T20:59:00.1447245Z",
      "SourceRefName": "refs/heads/metrics-observer",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "02bcc5bb-1d50-66e4-9b9f-736c0b1329e7",
        "Name": "Epsitha Ananth",
        "Email": "epananth@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "9e5742ee-d918-4543-99a1-616b44d67b54",
          "Name": "Ricardo Arenas",
          "Vote": 10
        },
        {
          "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
          "Name": "Missy Messa",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 49204,
      "Title": "Make \u0060packageParentPath\u0060 more specific",
      "Status": 3,
      "CreationDate": "2025-04-15T10:31:13.5988006Z",
      "ClosedDate": "2025-04-15T14:28:39.3141682Z",
      "SourceRefName": "refs/heads/more-specific-packageParentPath",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "69178761-8b3b-61ec-99bb-adddbae2c7d3",
        "Name": "Jakob Botsch Nielsen",
        "Email": "janielsen@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "9e5742ee-d918-4543-99a1-616b44d67b54",
          "Name": "Ricardo Arenas",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 49169,
      "Title": "remove organizations we do not have permissions to",
      "Status": 3,
      "CreationDate": "2025-04-11T22:20:53.4921169Z",
      "ClosedDate": "2025-04-14T17:21:06.5811844Z",
      "SourceRefName": "refs/heads/haruna/remove-invalid-organizations",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "b1f55bb3-0f83-65fa-8753-6f328b94345e",
        "Name": "Haruna Ogweda",
        "Email": "harunaogweda@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "0994e4e4-d484-4337-a745-54d4db413c14",
          "Name": "Ilya Skuratovsky",
          "Vote": 10
        },
        {
          "Id": "9e5742ee-d918-4543-99a1-616b44d67b54",
          "Name": "Ricardo Arenas",
          "Vote": 0
        }
      ]
    },
    {
      "PullRequestId": 49164,
      "Title": "Credscan failure during publishing - workaround for ICM 615434079",
      "Status": 3,
      "CreationDate": "2025-04-11T16:52:58.9254099Z",
      "ClosedDate": "2025-04-14T22:39:52.4443248Z",
      "SourceRefName": "refs/heads/meghnave/credscan_failure_workaround",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "11d4085b-6535-6a6c-a5ef-c87bedeca35e",
        "Name": "Meghna Verma",
        "Email": "meghnaverma@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "f0c34267-aedb-6a23-8361-271e79fc9284",
          "Name": "Tomas Weinfurt",
          "Vote": 10
        },
        {
          "Id": "b1f55bb3-0f83-65fa-8753-6f328b94345e",
          "Name": "Haruna Ogweda",
          "Vote": 10
        },
        {
          "Id": "69178761-8b3b-61ec-99bb-adddbae2c7d3",
          "Name": "Jakob Botsch Nielsen",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 49015,
      "Title": "Change Helix to not set \u0060conclusion\u0060 when \u0060status\u0060 is \u0060in_progress\u0060",
      "Status": 3,
      "CreationDate": "2025-04-08T07:20:46.2020953Z",
      "ClosedDate": "2025-04-08T19:23:20.4347989Z",
      "SourceRefName": "refs/heads/use-pending-when-in-progress",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "2fd97e11-691e-4007-9668-359c4c1b2a92",
        "Name": "Andy Gocke",
        "Email": "angocke@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "0994e4e4-d484-4337-a745-54d4db413c14",
          "Name": "Ilya Skuratovsky",
          "Vote": 10
        },
        {
          "Id": "87d5051d-03bf-42a5-82e6-7be0a9a3678c",
          "Name": "Mark Wilkie",
          "Vote": 0
        }
      ]
    },
    {
      "PullRequestId": 48682,
      "Title": "Exclude \u0060.cet\u0060 and \u0060.cedarcrest\u0060 queues from an alert",
      "Status": 3,
      "CreationDate": "2025-03-22T04:17:09.3232599Z",
      "ClosedDate": "2025-03-24T15:14:02.9030234Z",
      "SourceRefName": "refs/heads/dougbu/svc.alert.5277",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "a84ff60a-5a35-4c3f-8bb9-2e40b21f88b6",
        "Name": "Doug Bunting",
        "Email": "dougbu@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
          "Name": "Missy Messa",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 48681,
      "Title": "Fix queries used for mobile devices to match grafana alerting",
      "Status": 3,
      "CreationDate": "2025-03-22T03:21:33.2564381Z",
      "ClosedDate": "2025-03-24T20:56:49.9057991Z",
      "SourceRefName": "refs/heads/juhoyosa/add-more-queries-onprem",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "4954a309-db5f-67cc-af54-0f1695d4e970",
        "Name": "Juan Sebastian Hoyos Ayala",
        "Email": "juhoyosa@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "0994e4e4-d484-4337-a745-54d4db413c14",
          "Name": "Ilya Skuratovsky",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 48449,
      "Title": "[main] Update dependencies from dotnet/dnceng-shared",
      "Status": 3,
      "CreationDate": "2025-03-14T05:01:28.048116Z",
      "ClosedDate": "2025-05-01T17:32:06.4453134Z",
      "SourceRefName": "refs/heads/darc-main-51fc2a65-8127-4cfe-a029-df85e177776f",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "c81111e3-e146-69f1-b0a6-dd3ca4dde3a0",
        "Name": "ProductConstructionServiceProd",
        "Email": "72f988bf-86f1-41af-91ab-2d7cd011db47\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
          "Name": "Missy Messa",
          "Vote": 10
        },
        {
          "Id": "02bcc5bb-1d50-66e4-9b9f-736c0b1329e7",
          "Name": "Epsitha Ananth",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 48348,
      "Title": "Fix UserDb in helixapi uses password",
      "Status": 3,
      "CreationDate": "2025-03-12T17:00:17.5802335Z",
      "ClosedDate": "2025-03-13T17:54:56.9619664Z",
      "SourceRefName": "refs/heads/dev/enji/sql-secrets",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "6d5d7783-3f68-61b8-ada5-d9af8319d0c8",
        "Name": "Enji Eid",
        "Email": "enjieid@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "4954a309-db5f-67cc-af54-0f1695d4e970",
          "Name": "Juan Sebastian Hoyos Ayala",
          "Vote": 10
        },
        {
          "Id": "02bcc5bb-1d50-66e4-9b9f-736c0b1329e7",
          "Name": "Epsitha Ananth",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 48321,
      "Title": "[main] Update dependencies from dotnet/dnceng",
      "Status": 3,
      "CreationDate": "2025-03-12T05:01:37.5184443Z",
      "ClosedDate": "2025-05-01T21:30:31.4134207Z",
      "SourceRefName": "refs/heads/darc-main-6bedc7ec-4d5c-4c9d-ba9e-022f69a455f9",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "c81111e3-e146-69f1-b0a6-dd3ca4dde3a0",
        "Name": "ProductConstructionServiceProd",
        "Email": "72f988bf-86f1-41af-91ab-2d7cd011db47\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
          "Name": "Missy Messa",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 48303,
      "Title": "Remove unused SQL settings",
      "Status": 3,
      "CreationDate": "2025-03-11T14:35:20.1263072Z",
      "ClosedDate": "2025-03-11T19:01:28.1256352Z",
      "SourceRefName": "refs/heads/dev/enji/sql-fix",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "6d5d7783-3f68-61b8-ada5-d9af8319d0c8",
        "Name": "Enji Eid",
        "Email": "enjieid@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
          "Name": "Missy Messa",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 48206,
      "Title": "Remove reference to HelixSigningKV from code",
      "Status": 3,
      "CreationDate": "2025-03-07T22:39:24.7400183Z",
      "ClosedDate": "2025-03-12T19:54:32.1702559Z",
      "SourceRefName": "refs/heads/missymessa-6728",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
        "Name": "Missy Messa",
        "Email": "mjanecke@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "a84ff60a-5a35-4c3f-8bb9-2e40b21f88b6",
          "Name": "Doug Bunting",
          "Vote": 0
        },
        {
          "Id": "db0724ea-305e-418a-969c-779e49c58ad8",
          "Name": "David Foster (DEVOPS)",
          "Vote": 0
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 48203,
      "Title": "Fix AkaMs metrics collector",
      "Status": 3,
      "CreationDate": "2025-03-07T21:25:11.2690546Z",
      "ClosedDate": "2025-03-11T21:11:01.5272625Z",
      "SourceRefName": "refs/heads/mistucke/nnnn-fix-akams-observer",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
        "Name": "Michael Stuckey",
        "Email": "mistucke@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
          "Name": "Missy Messa",
          "Vote": 10
        },
        {
          "Id": "5981d0ba-743b-6d84-9319-ec043e802737",
          "Name": "Farhad Alizada",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 48201,
      "Title": "Fix telemetry client initialization in the autoscale actor to use connection...",
      "Status": 3,
      "CreationDate": "2025-03-07T17:09:49.2074374Z",
      "ClosedDate": "2025-03-07T21:55:17.7889819Z",
      "SourceRefName": "refs/heads/riarenas/fix-telemetry",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "9e5742ee-d918-4543-99a1-616b44d67b54",
        "Name": "Ricardo Arenas",
        "Email": "riarenas@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 48191,
      "Title": "Merge Production back into main",
      "Status": 3,
      "CreationDate": "2025-03-07T13:58:29.3088628Z",
      "ClosedDate": "2025-03-24T16:43:04.7833581Z",
      "SourceRefName": "refs/heads/production",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "9e5742ee-d918-4543-99a1-616b44d67b54",
        "Name": "Ricardo Arenas",
        "Email": "riarenas@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
          "Name": "Missy Messa",
          "Vote": 10
        },
        {
          "Id": "db0724ea-305e-418a-969c-779e49c58ad8",
          "Name": "David Foster (DEVOPS)",
          "Vote": 0
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 0
        }
      ]
    },
    {
      "PullRequestId": 48129,
      "Title": "Add configurable scale factor per queue",
      "Status": 3,
      "CreationDate": "2025-03-04T23:33:03.4888587Z",
      "ClosedDate": "2025-03-05T22:14:43.6935959Z",
      "SourceRefName": "refs/heads/riarenas/add-multiplier",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "9e5742ee-d918-4543-99a1-616b44d67b54",
        "Name": "Ricardo Arenas",
        "Email": "riarenas@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 48086,
      "Title": "Add IsExternal Property to StorageContainer table and filter",
      "Status": 3,
      "CreationDate": "2025-03-03T11:58:24.2702001Z",
      "ClosedDate": "2025-03-18T09:50:39.7856856Z",
      "SourceRefName": "refs/heads/dev/falizada/add-is-external",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "5981d0ba-743b-6d84-9319-ec043e802737",
        "Name": "Farhad Alizada",
        "Email": "falizada@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 48009,
      "Title": "Deleting package references for removed packages",
      "Status": 3,
      "CreationDate": "2025-02-27T22:42:01.4058998Z",
      "ClosedDate": "2025-02-27T23:04:50.7178264Z",
      "SourceRefName": "refs/heads/missymessa-remove-unused-libs",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
        "Name": "Missy Messa",
        "Email": "mjanecke@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 47956,
      "Title": "[main] Update dependencies from dotnet/dnceng-shared",
      "Status": 3,
      "CreationDate": "2025-02-26T05:02:09.7238823Z",
      "ClosedDate": "2025-03-11T22:22:49.0906142Z",
      "SourceRefName": "refs/heads/darc-main-50e7ab45-a9eb-424b-bdd4-3283addcfa21",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "c81111e3-e146-69f1-b0a6-dd3ca4dde3a0",
        "Name": "ProductConstructionServiceProd",
        "Email": "72f988bf-86f1-41af-91ab-2d7cd011db47\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
          "Name": "Missy Messa",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 47900,
      "Title": "[main] Update dependencies from dotnet/dnceng",
      "Status": 3,
      "CreationDate": "2025-02-25T05:01:58.2047265Z",
      "ClosedDate": "2025-03-12T17:32:37.6182153Z",
      "SourceRefName": "refs/heads/darc-main-df424632-6f4b-490e-a78c-87b7feb8101f",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "c81111e3-e146-69f1-b0a6-dd3ca4dde3a0",
        "Name": "ProductConstructionServiceProd",
        "Email": "72f988bf-86f1-41af-91ab-2d7cd011db47\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
          "Name": "Missy Messa",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 47871,
      "Title": "remove no needed firewall scripts",
      "Status": 3,
      "CreationDate": "2025-02-24T15:40:10.7046328Z",
      "ClosedDate": "2025-02-25T09:29:37.9545755Z",
      "SourceRefName": "refs/heads/dev/enji/remove-firewall",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "6d5d7783-3f68-61b8-ada5-d9af8319d0c8",
        "Name": "Enji Eid",
        "Email": "enjieid@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "9e5742ee-d918-4543-99a1-616b44d67b54",
          "Name": "Ricardo Arenas",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 47870,
      "Title": "use service principal to deploy helix-data",
      "Status": 3,
      "CreationDate": "2025-02-24T15:38:48.0321501Z",
      "ClosedDate": "2025-03-05T12:52:46.3584941Z",
      "SourceRefName": "refs/heads/dev/enji/update-helixdata-deployment",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "6d5d7783-3f68-61b8-ada5-d9af8319d0c8",
        "Name": "Enji Eid",
        "Email": "enjieid@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        },
        {
          "Id": "5981d0ba-743b-6d84-9319-ec043e802737",
          "Name": "Farhad Alizada",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 47788,
      "Title": "Add ListOnPremMachinesNeedingHelp tool",
      "Status": 3,
      "CreationDate": "2025-02-20T06:35:50.1047213Z",
      "ClosedDate": "2025-02-20T18:24:44.615177Z",
      "SourceRefName": "refs/heads/juhoyosa/add-onprem-tool",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "4954a309-db5f-67cc-af54-0f1695d4e970",
        "Name": "Juan Sebastian Hoyos Ayala",
        "Email": "juhoyosa@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "0994e4e4-d484-4337-a745-54d4db413c14",
          "Name": "Ilya Skuratovsky",
          "Vote": 0
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 47783,
      "Title": "Remove secrets related to rollout scorer",
      "Status": 3,
      "CreationDate": "2025-02-19T19:32:43.7261151Z",
      "ClosedDate": "2025-02-19T21:48:30.5333557Z",
      "SourceRefName": "refs/heads/missymessa-4658",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
        "Name": "Missy Messa",
        "Email": "mjanecke@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 47782,
      "Title": "Update DB using service connection",
      "Status": 3,
      "CreationDate": "2025-02-19T16:36:15.4546495Z",
      "ClosedDate": "2025-03-05T20:57:41.4054644Z",
      "SourceRefName": "refs/heads/dev/enji/sql-passwords",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "6d5d7783-3f68-61b8-ada5-d9af8319d0c8",
        "Name": "Enji Eid",
        "Email": "enjieid@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 47736,
      "Title": "Pin NuGet restore task version",
      "Status": 3,
      "CreationDate": "2025-02-18T09:11:21.9732797Z",
      "ClosedDate": "2025-02-18T17:52:51.2782783Z",
      "SourceRefName": "refs/heads/dev/janielsen/nuget-restore-task-version",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "69178761-8b3b-61ec-99bb-adddbae2c7d3",
        "Name": "Jakob Botsch Nielsen",
        "Email": "janielsen@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        },
        {
          "Id": "6d5d7783-3f68-61b8-ada5-d9af8319d0c8",
          "Name": "Enji Eid",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 47547,
      "Title": "Introduce the concept of a minCapacity to the autoscale configuration",
      "Status": 3,
      "CreationDate": "2025-02-12T08:20:21.0285644Z",
      "ClosedDate": "2025-02-12T23:03:00.4678137Z",
      "SourceRefName": "refs/heads/riarenas/add-min-scale",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "9e5742ee-d918-4543-99a1-616b44d67b54",
        "Name": "Ricardo Arenas",
        "Email": "riarenas@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "0994e4e4-d484-4337-a745-54d4db413c14",
          "Name": "Ilya Skuratovsky",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 0
        }
      ]
    },
    {
      "PullRequestId": 47541,
      "Title": "[main] Update dependencies from dotnet/dnceng-shared",
      "Status": 3,
      "CreationDate": "2025-02-12T05:01:23.3897556Z",
      "ClosedDate": "2025-02-21T19:17:50.115608Z",
      "SourceRefName": "refs/heads/darc-main-4b422bea-8e0b-4a50-a27f-17614ba1ff19",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "c81111e3-e146-69f1-b0a6-dd3ca4dde3a0",
        "Name": "ProductConstructionServiceProd",
        "Email": "72f988bf-86f1-41af-91ab-2d7cd011db47\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 47518,
      "Title": "Upload app package using the Service Principle",
      "Status": 3,
      "CreationDate": "2025-02-11T17:27:51.5329959Z",
      "ClosedDate": "2025-02-13T08:19:29.4376482Z",
      "SourceRefName": "refs/heads/dev/falizada/use-connected-to-upload-package",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "5981d0ba-743b-6d84-9319-ec043e802737",
        "Name": "Farhad Alizada",
        "Email": "falizada@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "9e5742ee-d918-4543-99a1-616b44d67b54",
          "Name": "Ricardo Arenas",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 47437,
      "Title": "Add container info to exception",
      "Status": 3,
      "CreationDate": "2025-02-10T09:14:50.3957555Z",
      "ClosedDate": "2025-02-11T15:34:47.7729028Z",
      "SourceRefName": "refs/heads/dev/falizada/add-more-logs-to-exception",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "5981d0ba-743b-6d84-9319-ec043e802737",
        "Name": "Farhad Alizada",
        "Email": "falizada@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "9e5742ee-d918-4543-99a1-616b44d67b54",
          "Name": "Ricardo Arenas",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 47427,
      "Title": "[main] Update dependencies from dotnet/dnceng",
      "Status": 3,
      "CreationDate": "2025-02-08T05:01:57.6461445Z",
      "ClosedDate": "2025-02-10T20:12:09.4369648Z",
      "SourceRefName": "refs/heads/darc-main-734e0d1a-e13d-4b10-a16f-2face0e768d2",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "c81111e3-e146-69f1-b0a6-dd3ca4dde3a0",
        "Name": "ProductConstructionServiceProd",
        "Email": "72f988bf-86f1-41af-91ab-2d7cd011db47\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 47318,
      "Title": "Revert \u0022Merged PR 47204: Use the connected account for context\u0022",
      "Status": 3,
      "CreationDate": "2025-02-04T18:52:05.2514266Z",
      "ClosedDate": "2025-02-04T19:25:56.5226588Z",
      "SourceRefName": "refs/heads/dev/falizada/revert-useconnected",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "5981d0ba-743b-6d84-9319-ec043e802737",
        "Name": "Farhad Alizada",
        "Email": "falizada@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "9e5742ee-d918-4543-99a1-616b44d67b54",
          "Name": "Ricardo Arenas",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 47291,
      "Title": "Move secret to arcade",
      "Status": 3,
      "CreationDate": "2025-02-03T17:36:11.7050794Z",
      "ClosedDate": "2025-02-05T17:11:13.5868459Z",
      "SourceRefName": "refs/heads/move-secret-to-arcade",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "ab548af8-1ef9-4928-8fd6-2014ea725a67",
        "Name": "Matt Mitchell (.NET)",
        "Email": "mmitche@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "9e5742ee-d918-4543-99a1-616b44d67b54",
          "Name": "Ricardo Arenas",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 47277,
      "Title": "Merge Production =\u003E main",
      "Status": 3,
      "CreationDate": "2025-02-01T00:40:27.3179957Z",
      "ClosedDate": "2025-02-03T17:46:26.5083519Z",
      "SourceRefName": "refs/heads/production",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "db0724ea-305e-418a-969c-779e49c58ad8",
        "Name": "David Foster (DEVOPS)",
        "Email": "davfost@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "a84ff60a-5a35-4c3f-8bb9-2e40b21f88b6",
          "Name": "Doug Bunting",
          "Vote": 0
        },
        {
          "Id": "0994e4e4-d484-4337-a745-54d4db413c14",
          "Name": "Ilya Skuratovsky",
          "Vote": 0
        },
        {
          "Id": "9e5742ee-d918-4543-99a1-616b44d67b54",
          "Name": "Ricardo Arenas",
          "Vote": 10
        },
        {
          "Id": "db0724ea-305e-418a-969c-779e49c58ad8",
          "Name": "David Foster (DEVOPS)",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 0
        }
      ]
    },
    {
      "PullRequestId": 47231,
      "Title": "[main] Update dependencies from dotnet/dnceng-shared",
      "Status": 3,
      "CreationDate": "2025-01-31T05:01:54.0121286Z",
      "ClosedDate": "2025-02-07T18:36:22.9190846Z",
      "SourceRefName": "refs/heads/darc-main-8ca33b4a-ad99-42f6-a3a5-89746addef08",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "c81111e3-e146-69f1-b0a6-dd3ca4dde3a0",
        "Name": "ProductConstructionServiceProd",
        "Email": "72f988bf-86f1-41af-91ab-2d7cd011db47\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "4954a309-db5f-67cc-af54-0f1695d4e970",
          "Name": "Juan Sebastian Hoyos Ayala",
          "Vote": 10
        },
        {
          "Id": "9e5742ee-d918-4543-99a1-616b44d67b54",
          "Name": "Ricardo Arenas",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 47215,
      "Title": "Update autoscale alerts runbook",
      "Status": 3,
      "CreationDate": "2025-01-30T17:18:38.8911678Z",
      "ClosedDate": "2025-01-30T19:34:56.8538863Z",
      "SourceRefName": "refs/heads/meghnave/update_autoscale_runbook",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "11d4085b-6535-6a6c-a5ef-c87bedeca35e",
        "Name": "Meghna Verma",
        "Email": "meghnaverma@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "9e5742ee-d918-4543-99a1-616b44d67b54",
          "Name": "Ricardo Arenas",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 47204,
      "Title": "Use the connected account for context",
      "Status": 3,
      "CreationDate": "2025-01-30T12:14:23.0722448Z",
      "ClosedDate": "2025-02-03T13:56:08.3562613Z",
      "SourceRefName": "refs/heads/dev/falizada/upload-apppackage-via-mi",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "5981d0ba-743b-6d84-9319-ec043e802737",
        "Name": "Farhad Alizada",
        "Email": "falizada@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "0994e4e4-d484-4337-a745-54d4db413c14",
          "Name": "Ilya Skuratovsky",
          "Vote": 10
        },
        {
          "Id": "69178761-8b3b-61ec-99bb-adddbae2c7d3",
          "Name": "Jakob Botsch Nielsen",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 47184,
      "Title": "Deploy production VMSS via templates",
      "Status": 3,
      "CreationDate": "2025-01-29T18:58:55.7458136Z",
      "ClosedDate": "2025-01-31T09:59:28.3895124Z",
      "SourceRefName": "refs/heads/dev/janielsen/vmss-prod-deployment",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "69178761-8b3b-61ec-99bb-adddbae2c7d3",
        "Name": "Jakob Botsch Nielsen",
        "Email": "janielsen@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "9e5742ee-d918-4543-99a1-616b44d67b54",
          "Name": "Ricardo Arenas",
          "Vote": 10
        },
        {
          "Id": "5981d0ba-743b-6d84-9319-ec043e802737",
          "Name": "Farhad Alizada",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 47092,
      "Title": "Add secrets to VMSS template",
      "Status": 3,
      "CreationDate": "2025-01-27T16:22:53.9452003Z",
      "ClosedDate": "2025-01-29T09:02:34.3534862Z",
      "SourceRefName": "refs/heads/dev/janielsen/vmss-add-secrets",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "69178761-8b3b-61ec-99bb-adddbae2c7d3",
        "Name": "Jakob Botsch Nielsen",
        "Email": "janielsen@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "4954a309-db5f-67cc-af54-0f1695d4e970",
          "Name": "Juan Sebastian Hoyos Ayala",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        },
        {
          "Id": "5981d0ba-743b-6d84-9319-ec043e802737",
          "Name": "Farhad Alizada",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 47017,
      "Title": "Remove IaaSDiagnostics extension from VMSS",
      "Status": 3,
      "CreationDate": "2025-01-24T11:50:52.9560989Z",
      "ClosedDate": "2025-02-07T09:59:26.2541625Z",
      "SourceRefName": "refs/heads/dev/janielsen/vmss-no-diagnostics",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "69178761-8b3b-61ec-99bb-adddbae2c7d3",
        "Name": "Jakob Botsch Nielsen",
        "Email": "janielsen@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "4954a309-db5f-67cc-af54-0f1695d4e970",
          "Name": "Juan Sebastian Hoyos Ayala",
          "Vote": 10
        },
        {
          "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
          "Name": "Missy Messa",
          "Vote": 10
        },
        {
          "Id": "5981d0ba-743b-6d84-9319-ec043e802737",
          "Name": "Farhad Alizada",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 47016,
      "Title": "Skip production deployment of VMSS from templates",
      "Status": 3,
      "CreationDate": "2025-01-24T11:24:37.8719098Z",
      "ClosedDate": "2025-01-24T17:01:26.3473903Z",
      "SourceRefName": "refs/heads/dev/janielsen/vmss-skip-prod-deployment",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "69178761-8b3b-61ec-99bb-adddbae2c7d3",
        "Name": "Jakob Botsch Nielsen",
        "Email": "janielsen@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "9e5742ee-d918-4543-99a1-616b44d67b54",
          "Name": "Ricardo Arenas",
          "Vote": 10
        },
        {
          "Id": "5981d0ba-743b-6d84-9319-ec043e802737",
          "Name": "Farhad Alizada",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 46990,
      "Title": "[Service Fabric] Update auth type of downloading file in VMSS during the provision",
      "Status": 3,
      "CreationDate": "2025-01-23T12:26:26.1730524Z",
      "ClosedDate": "2025-02-06T21:46:17.9297365Z",
      "SourceRefName": "refs/heads/dev/enji/Use-MI-with-CustomScriptextension",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "6d5d7783-3f68-61b8-ada5-d9af8319d0c8",
        "Name": "Enji Eid",
        "Email": "enjieid@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
          "Name": "Missy Messa",
          "Vote": 10
        },
        {
          "Id": "69178761-8b3b-61ec-99bb-adddbae2c7d3",
          "Name": "Jakob Botsch Nielsen",
          "Vote": 10
        },
        {
          "Id": "5981d0ba-743b-6d84-9319-ec043e802737",
          "Name": "Farhad Alizada",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 46955,
      "Title": "Add a bicep template for VMSS deployment",
      "Status": 3,
      "CreationDate": "2025-01-22T11:11:51.0116823Z",
      "ClosedDate": "2025-01-23T09:50:12.9339469Z",
      "SourceRefName": "refs/heads/dev/janielsen/vmss-bicep-template",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "69178761-8b3b-61ec-99bb-adddbae2c7d3",
        "Name": "Jakob Botsch Nielsen",
        "Email": "janielsen@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "da8e23bb-3123-4efe-9074-87b88acf60b7",
          "Name": "Christopher Costa",
          "Vote": 10
        },
        {
          "Id": "5981d0ba-743b-6d84-9319-ec043e802737",
          "Name": "Farhad Alizada",
          "Vote": 0
        }
      ]
    },
    {
      "PullRequestId": 46779,
      "Title": "Update Diagnostics fabricSettings to use MI ",
      "Status": 3,
      "CreationDate": "2025-01-16T08:49:56.3240542Z",
      "ClosedDate": "2025-01-17T09:53:15.1059845Z",
      "SourceRefName": "refs/heads/dev/falizada/update-sf-diag-settings",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "5981d0ba-743b-6d84-9319-ec043e802737",
        "Name": "Farhad Alizada",
        "Email": "falizada@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 46728,
      "Title": "[main] Update dependencies from dotnet/dnceng",
      "Status": 3,
      "CreationDate": "2025-01-15T05:02:16.7546254Z",
      "ClosedDate": "2025-02-07T18:05:44.1185076Z",
      "SourceRefName": "refs/heads/darc-main-55f48001-2cea-4232-b4e8-c74a543fc14c",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "c81111e3-e146-69f1-b0a6-dd3ca4dde3a0",
        "Name": "ProductConstructionServiceProd",
        "Email": "72f988bf-86f1-41af-91ab-2d7cd011db47\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 46724,
      "Title": "Revert 1ES PT Release Tasks bits",
      "Status": 3,
      "CreationDate": "2025-01-14T21:47:27.8375603Z",
      "ClosedDate": "2025-01-14T23:38:51.1316292Z",
      "SourceRefName": "refs/heads/mistucke/4311-revert-release-tasks",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
        "Name": "Michael Stuckey",
        "Email": "mistucke@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "4954a309-db5f-67cc-af54-0f1695d4e970",
          "Name": "Juan Sebastian Hoyos Ayala",
          "Vote": 10
        },
        {
          "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
          "Name": "Missy Messa",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 46597,
      "Title": "Fixup some additional wayward release tasks",
      "Status": 3,
      "CreationDate": "2025-01-09T00:07:27.6442168Z",
      "ClosedDate": "2025-01-09T00:40:20.2152017Z",
      "SourceRefName": "refs/heads/mistucke/4311-part-2",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
        "Name": "Michael Stuckey",
        "Email": "mistucke@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "ab548af8-1ef9-4928-8fd6-2014ea725a67",
          "Name": "Matt Mitchell (.NET)",
          "Vote": 0
        },
        {
          "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
          "Name": "Missy Messa",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 46560,
      "Title": "[main] Update dependencies from dotnet/dnceng",
      "Status": 3,
      "CreationDate": "2025-01-08T05:01:31.4054157Z",
      "ClosedDate": "2025-01-09T00:49:44.5612699Z",
      "SourceRefName": "refs/heads/darc-main-8b354566-3a5b-4686-a409-7f4ccebe8607",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "c81111e3-e146-69f1-b0a6-dd3ca4dde3a0",
        "Name": "ProductConstructionServiceProd",
        "Email": "72f988bf-86f1-41af-91ab-2d7cd011db47\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 46555,
      "Title": "Update helix-admin list to account for team member changes",
      "Status": 3,
      "CreationDate": "2025-01-07T22:06:42.9653773Z",
      "ClosedDate": "2025-01-08T19:07:03.3624483Z",
      "SourceRefName": "refs/heads/meghnave/update-helix-admin-list",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "11d4085b-6535-6a6c-a5ef-c87bedeca35e",
        "Name": "Meghna Verma",
        "Email": "meghnaverma@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "a84ff60a-5a35-4c3f-8bb9-2e40b21f88b6",
          "Name": "Doug Bunting",
          "Vote": 10
        },
        {
          "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
          "Name": "Missy Messa",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 46488,
      "Title": "[main] Update dependencies from dotnet/dnceng",
      "Status": 3,
      "CreationDate": "2025-01-04T05:01:35.097041Z",
      "ClosedDate": "2025-01-07T19:35:37.4754765Z",
      "SourceRefName": "refs/heads/darc-main-76f7b805-c38c-4cc7-b5ba-76672da4638d",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "c81111e3-e146-69f1-b0a6-dd3ca4dde3a0",
        "Name": "ProductConstructionServiceProd",
        "Email": "72f988bf-86f1-41af-91ab-2d7cd011db47\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 46487,
      "Title": "[main] Update dependencies from dotnet/dnceng-shared",
      "Status": 3,
      "CreationDate": "2025-01-04T05:01:33.3783Z",
      "ClosedDate": "2025-01-07T22:56:11.4928266Z",
      "SourceRefName": "refs/heads/darc-main-0807d97e-2619-4051-9db0-32344f2c2259",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "c81111e3-e146-69f1-b0a6-dd3ca4dde3a0",
        "Name": "ProductConstructionServiceProd",
        "Email": "72f988bf-86f1-41af-91ab-2d7cd011db47\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "b1f55bb3-0f83-65fa-8753-6f328b94345e",
          "Name": "Haruna Ogweda",
          "Vote": 10
        },
        {
          "Id": "db0724ea-305e-418a-969c-779e49c58ad8",
          "Name": "David Foster (DEVOPS)",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 46460,
      "Title": "[main] Update dependencies from dotnet/dnceng-shared",
      "Status": 3,
      "CreationDate": "2025-01-03T05:01:32.6142276Z",
      "ClosedDate": "2025-01-03T21:46:53.841062Z",
      "SourceRefName": "refs/heads/darc-main-8987be80-f88f-4fad-a529-9a356673d812",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "c81111e3-e146-69f1-b0a6-dd3ca4dde3a0",
        "Name": "ProductConstructionServiceProd",
        "Email": "72f988bf-86f1-41af-91ab-2d7cd011db47\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 46410,
      "Title": "Use release jobs in the deployment stage",
      "Status": 3,
      "CreationDate": "2024-12-31T18:39:56.7021672Z",
      "ClosedDate": "2025-01-08T23:33:06.4321581Z",
      "SourceRefName": "refs/heads/use-release-job",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "ab548af8-1ef9-4928-8fd6-2014ea725a67",
        "Name": "Matt Mitchell (.NET)",
        "Email": "mmitche@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 46041,
      "Title": "[main] Update dependencies from dotnet/dnceng",
      "Status": 3,
      "CreationDate": "2024-12-14T13:30:11.9752581Z",
      "ClosedDate": "2024-12-30T22:45:43.6574181Z",
      "SourceRefName": "refs/heads/darc-main-ac6fc9f7-a6ab-4a93-98be-229a4b20bf3f",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "e247ef8c-b6cf-6ca6-9c94-5a3a9c583c07",
        "Name": "maestro-prod-Primary",
        "Email": "72f988bf-86f1-41af-91ab-2d7cd011db47\\610d53f3-8c41-42a0-9941-cb44eecfa176"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 45847,
      "Title": "Rolling back the Azure.Identity nuget to version 1.12.1",
      "Status": 3,
      "CreationDate": "2024-12-10T21:13:08.3492333Z",
      "ClosedDate": "2024-12-10T21:40:15.1687517Z",
      "SourceRefName": "refs/heads/dev/davfost/20241210_BuildFailure",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "db0724ea-305e-418a-969c-779e49c58ad8",
        "Name": "David Foster (DEVOPS)",
        "Email": "davfost@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "0994e4e4-d484-4337-a745-54d4db413c14",
          "Name": "Ilya Skuratovsky",
          "Vote": 0
        },
        {
          "Id": "9e5742ee-d918-4543-99a1-616b44d67b54",
          "Name": "Ricardo Arenas",
          "Vote": 10
        },
        {
          "Id": "b1f55bb3-0f83-65fa-8753-6f328b94345e",
          "Name": "Haruna Ogweda",
          "Vote": 0
        },
        {
          "Id": "db0724ea-305e-418a-969c-779e49c58ad8",
          "Name": "David Foster (DEVOPS)",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 0
        }
      ]
    },
    {
      "PullRequestId": 45732,
      "Title": "[main] Update dependencies from dotnet/dnceng-shared",
      "Status": 3,
      "CreationDate": "2024-12-06T13:32:25.7109131Z",
      "ClosedDate": "2024-12-31T19:38:51.2624596Z",
      "SourceRefName": "refs/heads/darc-main-721fdaea-5294-48f8-9562-9d185cdeb680",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "e247ef8c-b6cf-6ca6-9c94-5a3a9c583c07",
        "Name": "maestro-prod-Primary",
        "Email": "72f988bf-86f1-41af-91ab-2d7cd011db47\\610d53f3-8c41-42a0-9941-cb44eecfa176"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "a84ff60a-5a35-4c3f-8bb9-2e40b21f88b6",
          "Name": "Doug Bunting",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 45631,
      "Title": "Look for AzDO issues in PRs as well as GitHub issues",
      "Status": 3,
      "CreationDate": "2024-12-03T19:01:18.0068558Z",
      "ClosedDate": "2024-12-04T16:17:50.4413523Z",
      "SourceRefName": "refs/heads/missymessa-7191",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
        "Name": "Missy Messa",
        "Email": "mjanecke@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "a84ff60a-5a35-4c3f-8bb9-2e40b21f88b6",
          "Name": "Doug Bunting",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 45421,
      "Title": "enable PoliCheck and TSA in dotnet-helix-service-ci pipeline",
      "Status": 3,
      "CreationDate": "2024-11-26T23:56:40.6679543Z",
      "ClosedDate": "2024-12-04T18:50:40.3601945Z",
      "SourceRefName": "refs/heads/haruna/tsa-compliance",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "b1f55bb3-0f83-65fa-8753-6f328b94345e",
        "Name": "Haruna Ogweda",
        "Email": "harunaogweda@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "9e5742ee-d918-4543-99a1-616b44d67b54",
          "Name": "Ricardo Arenas",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 45191,
      "Title": "[SECURITY] Bump System.Text.Json from 8.0.4 to 8.0.5 in /src",
      "Status": 3,
      "CreationDate": "2024-11-21T05:08:39.885722Z",
      "ClosedDate": "2024-11-22T18:55:10.3892846Z",
      "SourceRefName": "refs/heads/dependabot/nuget/src/System.Text.Json-8.0.5-71988",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "00000072-0000-8888-8000-000000000000",
        "Name": "Dependabot",
        "Email": "00000072-0000-8888-8000-000000000000@2c895908-04e0-4952-89fd-54b0046d6288"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "9e5742ee-d918-4543-99a1-616b44d67b54",
          "Name": "Ricardo Arenas",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 45159,
      "Title": "[A11y] Use underline text style instead of \u003Cu\u003E tags",
      "Status": 3,
      "CreationDate": "2024-11-20T16:03:12.274834Z",
      "ClosedDate": "2024-11-20T17:07:25.1680961Z",
      "SourceRefName": "refs/heads/riarenas/fix-underline-styling",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "9e5742ee-d918-4543-99a1-616b44d67b54",
        "Name": "Ricardo Arenas",
        "Email": "riarenas@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "0994e4e4-d484-4337-a745-54d4db413c14",
          "Name": "Ilya Skuratovsky",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 44959,
      "Title": "Post-deployment merge of the production branch back to main branch",
      "Status": 3,
      "CreationDate": "2024-11-13T21:46:24.9229245Z",
      "ClosedDate": "2024-11-13T22:11:13.3140566Z",
      "SourceRefName": "refs/heads/production",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "db0724ea-305e-418a-969c-779e49c58ad8",
        "Name": "David Foster (DEVOPS)",
        "Email": "davfost@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "9e5742ee-d918-4543-99a1-616b44d67b54",
          "Name": "Ricardo Arenas",
          "Vote": 10
        },
        {
          "Id": "db0724ea-305e-418a-969c-779e49c58ad8",
          "Name": "David Foster (DEVOPS)",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 44946,
      "Title": "Move the definition SF cluster from Azure Portal to bicep template",
      "Status": 3,
      "CreationDate": "2024-11-13T14:13:36.7115174Z",
      "ClosedDate": "2025-01-03T10:06:46.1705853Z",
      "SourceRefName": "refs/heads/dev/falizada/service-fabric-deployment",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "5981d0ba-743b-6d84-9319-ec043e802737",
        "Name": "Farhad Alizada",
        "Email": "falizada@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "a84ff60a-5a35-4c3f-8bb9-2e40b21f88b6",
          "Name": "Doug Bunting",
          "Vote": 10
        },
        {
          "Id": "0994e4e4-d484-4337-a745-54d4db413c14",
          "Name": "Ilya Skuratovsky",
          "Vote": 0
        }
      ]
    },
    {
      "PullRequestId": 44833,
      "Title": "Fix passing rsas and wsas to JobCreationRequest",
      "Status": 3,
      "CreationDate": "2024-11-08T15:37:31.5536539Z",
      "ClosedDate": "2024-11-09T09:14:54.4437741Z",
      "SourceRefName": "refs/heads/dev/srozsival/fix-job-creation-request-wsas",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "14b37c7b-4c51-6bd6-b73e-63b8a6db0616",
        "Name": "Simon Rozsival",
        "Email": "srozsival@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
          "Name": "Missy Messa",
          "Vote": 10
        },
        {
          "Id": "5981d0ba-743b-6d84-9319-ec043e802737",
          "Name": "Farhad Alizada",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 44832,
      "Title": "Remove the creation of resource group functionality in Storage account creation",
      "Status": 3,
      "CreationDate": "2024-11-08T14:20:00.4426464Z",
      "ClosedDate": "2024-11-11T12:23:10.8107106Z",
      "SourceRefName": "refs/heads/dev/falizada/remove-resource-group-creation-deprecate",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "5981d0ba-743b-6d84-9319-ec043e802737",
        "Name": "Farhad Alizada",
        "Email": "falizada@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f",
          "Name": "Missy Messa",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 44604,
      "Title": "Disable shared key access for newly created storage accounts in tests",
      "Status": 3,
      "CreationDate": "2024-11-04T12:00:51.9065535Z",
      "ClosedDate": "2024-11-23T12:02:19.1816901Z",
      "SourceRefName": "refs/heads/dev/srozsival/disable-shared-key-access-to-storage-accounts-created-by-azure-resource-helper",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "14b37c7b-4c51-6bd6-b73e-63b8a6db0616",
        "Name": "Simon Rozsival",
        "Email": "srozsival@microsoft.com"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        },
        {
          "Id": "da8e23bb-3123-4efe-9074-87b88acf60b7",
          "Name": "Christopher Costa",
          "Vote": 10
        },
        {
          "Id": "5981d0ba-743b-6d84-9319-ec043e802737",
          "Name": "Farhad Alizada",
          "Vote": 10
        }
      ]
    },
    {
      "PullRequestId": 44473,
      "Title": "[main] Update dependencies from dotnet/dnceng",
      "Status": 3,
      "CreationDate": "2024-10-29T12:10:05.5418871Z",
      "ClosedDate": "2024-12-14T01:35:52.9836523Z",
      "SourceRefName": "refs/heads/darc-main-7e587618-7db1-422f-9f2f-c9fdce65b50b",
      "TargetRefName": "refs/heads/main",
      "Creator": {
        "Id": "e247ef8c-b6cf-6ca6-9c94-5a3a9c583c07",
        "Name": "maestro-prod-Primary",
        "Email": "72f988bf-86f1-41af-91ab-2d7cd011db47\\610d53f3-8c41-42a0-9941-cb44eecfa176"
      },
      "Reviewers": [
        {
          "Id": "5d578427-4dda-426c-8212-0760e978f0ab",
          "Name": "[TEAM FOUNDATION]\\MaWilkie\u0027s Direct Reports",
          "Vote": 10
        },
        {
          "Id": "bd413ef1-76d5-6333-81e6-82cd5d6c365d",
          "Name": "Michael Stuckey",
          "Vote": 10
        }
      ]
    }
  ]
}
```


- **Raw Results**:
```json
{
  "ai_tool_selection_response": "{\n  \u0022tool\u0022: \u0022get_pull_requests_by_closed_date\u0022,\n  \u0022parameters\u0022: {\n    \u0022projectName\u0022: \u0022internal\u0022,\n    \u0022repositoryName\u0022: \u0022dotnet-helix-service\u0022,\n    \u0022targetBranch\u0022: \u0022refs/heads/main\u0022,\n    \u0022beforeClosedDate\u0022: \u00222025-07-01\u0022,\n    \u0022status\u0022: \u0022completed\u0022\n  }\n}",
  "raw_result": "{\u0022content\u0022:[{\u0022type\u0022:\u0022text\u0022,\u0022text\u0022:\u0022{\\r\\n  \\u0022TotalCount\\u0022: 101,\\r\\n  \\u0022FilteredBy\\u0022: {\\r\\n    \\u0022Status\\u0022: \\u0022completed\\u0022,\\r\\n    \\u0022TargetBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022TimeRangeType\\u0022: \\u0022closed\\u0022,\\r\\n    \\u0022BeforeClosedDate\\u0022: \\u00222025-07-01 00:00:00\\u0022,\\r\\n    \\u0022AfterClosedDate\\u0022: null,\\r\\n    \\u0022MaxResults\\u0022: null\\r\\n  },\\r\\n  \\u0022PullRequests\\u0022: [\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 51170,\\r\\n      \\u0022Title\\u0022: \\u0022A11y fixes for banner landmark\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-06-25T22:22:21.3719358Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-06-26T21:10:01.55478Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/missymessa-7877\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022mjanecke@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022f0c34267-aedb-6a23-8361-271e79fc9284\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Tomas Weinfurt\\u0022,\\r\\n          \\u0022Vote\\u0022: 0\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 51079,\\r\\n      \\u0022Title\\u0022: \\u0022[main] Update dependencies from dotnet/dnceng\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-06-20T02:01:52.7923941Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-06-20T21:39:28.5070141Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/darc-main-0936e357-3e68-4f96-b5ef-4aaa9acaaa2c\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022ProductConstructionServiceProd\\u0022,\\r\\n        \\u0022Email\\u0022: \\u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 50933,\\r\\n      \\u0022Title\\u0022: \\u0022Remove Kusto SAS reference\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-06-16T22:22:08.2524857Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-06-18T23:01:11.6018651Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/removeKusto\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u002202bcc5bb-1d50-66e4-9b9f-736c0b1329e7\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Epsitha Ananth\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022epananth@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 50794,\\r\\n      \\u0022Title\\u0022: \\u0022Fix missing images in Build Analysis checks\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-06-12T10:37:02.0639165Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-06-12T16:10:51.9518503Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/alkpli/images\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022abd4b441-4b86-457c-a2d9-e09243ccd846\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Alexander K\\\\u00F6plinger\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022alkpli@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 50697,\\r\\n      \\u0022Title\\u0022: \\u0022[main] Update dependencies from dotnet/dnceng-shared\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-06-07T02:01:09.277749Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-06-18T05:38:03.8992942Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/darc-main-f1df5d2d-38d8-4da1-b262-9526fbb86732\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022ProductConstructionServiceProd\\u0022,\\r\\n        \\u0022Email\\u0022: \\u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 50691,\\r\\n      \\u0022Title\\u0022: \\u0022Refactor Helix Service to use AwesomeAssertions 9.0.0\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-06-06T16:28:01.6786592Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-06-06T18:45:44.8118992Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/missymessa-5408\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022mjanecke@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022db0724ea-305e-418a-969c-779e49c58ad8\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022David Foster (DEVOPS)\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 50688,\\r\\n      \\u0022Title\\u0022: \\u0022Merge back production -\\\\u003E main 06-06-2025\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-06-06T16:15:40.375998Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-06-06T16:39:56.934887Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/production\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022db0724ea-305e-418a-969c-779e49c58ad8\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022David Foster (DEVOPS)\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022davfost@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022f0c34267-aedb-6a23-8361-271e79fc9284\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Tomas Weinfurt\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022db0724ea-305e-418a-969c-779e49c58ad8\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022David Foster (DEVOPS)\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 50640,\\r\\n      \\u0022Title\\u0022: \\u0022Update deployment steps to be a \\\\u0022release\\\\u0022 job\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-06-04T21:38:28.4782363Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-06-30T18:22:06.304234Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/chcosta/refactor-release\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022da8e23bb-3123-4efe-9074-87b88acf60b7\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Christopher Costa\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022chcosta@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 50605,\\r\\n      \\u0022Title\\u0022: \\u0022Refactor EventHub in Helix Service to use modern Azure SDK\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-06-03T22:55:48.0565253Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-06-13T20:41:15.6244576Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/missymessa-893\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022mjanecke@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 50532,\\r\\n      \\u0022Title\\u0022: \\u0022[main] Update dependencies from dotnet/dnceng\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-06-01T02:01:42.794294Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-06-04T14:22:25.9775097Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/darc-main-064daa12-c6d5-4af9-984f-b55b36d1370d\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022ProductConstructionServiceProd\\u0022,\\r\\n        \\u0022Email\\u0022: \\u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 50520,\\r\\n      \\u0022Title\\u0022: \\u0022[main] Update dependencies from dotnet/dnceng-shared\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-05-31T02:02:05.8997475Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-06-05T19:28:34.4872958Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/darc-main-54aec916-b41f-470d-9a32-3dac1d7d0b31\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022ProductConstructionServiceProd\\u0022,\\r\\n        \\u0022Email\\u0022: \\u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 50412,\\r\\n      \\u0022Title\\u0022: \\u0022Add TimeProvider singleton for GitHubAppTokenProvider DI change in Microsoft....\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-05-27T17:37:35.1648798Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-05-27T22:59:54.6132404Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/chcosta/timeprovider-update\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022da8e23bb-3123-4efe-9074-87b88acf60b7\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Christopher Costa\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022chcosta@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 50394,\\r\\n      \\u0022Title\\u0022: \\u0022Update Dnceng team members.\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-05-26T12:17:27.1842241Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-05-27T16:53:53.0099128Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/ondrejsmid/update-dncengteam-members\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022a8ab78a9-2d24-67a5-8426-61435ee7fb35\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Ondrej Smid\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022ondrejsmid@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 50301,\\r\\n      \\u0022Title\\u0022: \\u0022Refactored Helix Service to use Azure.Messaging.Service instead of Microsoft.Azure.ServiceBus\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-05-21T22:36:20.6015957Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-06-02T15:17:52.7673921Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/missymessa-refactor-servicebus-libs\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022mjanecke@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022db0724ea-305e-418a-969c-779e49c58ad8\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022David Foster (DEVOPS)\\u0022,\\r\\n          \\u0022Vote\\u0022: 0\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022da8e23bb-3123-4efe-9074-87b88acf60b7\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Christopher Costa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 50228,\\r\\n      \\u0022Title\\u0022: \\u0022[main] Update dependencies from dotnet/dnceng\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-05-20T02:02:08.8576677Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-05-28T15:02:13.9773006Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/darc-main-b8f45194-9b8d-4fbd-bdcb-a10962bc497c\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022ProductConstructionServiceProd\\u0022,\\r\\n        \\u0022Email\\u0022: \\u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 50221,\\r\\n      \\u0022Title\\u0022: \\u0022Remove unused namespaces\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-05-20T00:07:07.2843314Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-05-20T00:34:50.0213297Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/missymessa-888\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022mjanecke@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 50210,\\r\\n      \\u0022Title\\u0022: \\u0022Removed unused variables\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-05-19T23:07:05.6846678Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-05-19T23:38:08.8599568Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/missymessa-887\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022mjanecke@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 50132,\\r\\n      \\u0022Title\\u0022: \\u0022Merge back production -\\\\u003E main 05-16-2025\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-05-16T16:24:00.6987162Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-05-16T17:04:34.4224333Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/production\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022db0724ea-305e-418a-969c-779e49c58ad8\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022David Foster (DEVOPS)\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022davfost@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022db0724ea-305e-418a-969c-779e49c58ad8\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022David Foster (DEVOPS)\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 50088,\\r\\n      \\u0022Title\\u0022: \\u0022Remove former teammates\\\\u0027 aliases from Startup.Auth.cs\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-05-15T20:52:09.9700697Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-05-16T22:32:51.0194763Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/missymessa-remove-former-teammates\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022mjanecke@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00224954a309-db5f-67cc-af54-0f1695d4e970\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Juan Sebastian Hoyos Ayala\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u002211d4085b-6535-6a6c-a5ef-c87bedeca35e\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Meghna Verma\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 49940,\\r\\n      \\u0022Title\\u0022: \\u0022Return azure storage links from listfiles API\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-05-09T16:40:22.6396076Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-05-09T18:02:08.4775139Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/janielsen/listfiles-azure-urls\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u002269178761-8b3b-61ec-99bb-adddbae2c7d3\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Jakob Botsch Nielsen\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022janielsen@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u002202bcc5bb-1d50-66e4-9b9f-736c0b1329e7\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Epsitha Ananth\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 49870,\\r\\n      \\u0022Title\\u0022: \\u0022[main] Update dependencies from dotnet/dnceng-shared\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-05-08T02:01:51.4631398Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-05-19T22:04:01.6617426Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/darc-main-4a7d0498-b0ff-4014-bee7-211a19b7d337\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022ProductConstructionServiceProd\\u0022,\\r\\n        \\u0022Email\\u0022: \\u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1f55bb3-0f83-65fa-8753-6f328b94345e\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Haruna Ogweda\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 0\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 49821,\\r\\n      \\u0022Title\\u0022: \\u0022[main] Update dependencies from dotnet/dnceng\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-05-07T02:01:32.5976291Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-05-16T22:33:38.1911325Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/darc-main-b41dc460-4e9c-457a-85aa-4dc74a7684e9\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022ProductConstructionServiceProd\\u0022,\\r\\n        \\u0022Email\\u0022: \\u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 49817,\\r\\n      \\u0022Title\\u0022: \\u0022Update YAML to use .NET 8\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-05-06T21:31:00.5763498Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-05-07T17:42:25.1494838Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/missymessa-2412\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022mjanecke@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022a84ff60a-5a35-4c3f-8bb9-2e40b21f88b6\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Doug Bunting\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 49811,\\r\\n      \\u0022Title\\u0022: \\u0022Switch user delegation SAS to use HelixStorageHelper._isExternal\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-05-06T16:10:30.1754256Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-05-06T20:03:16.7611772Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/janielsen/no-sas-public\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u002269178761-8b3b-61ec-99bb-adddbae2c7d3\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Jakob Botsch Nielsen\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022janielsen@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 49727,\\r\\n      \\u0022Title\\u0022: \\u0022Remove old admins\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-05-04T18:31:17.5815119Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-05-05T16:16:41.8249007Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dougbu/quick.admin.cleanup.5534\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022a84ff60a-5a35-4c3f-8bb9-2e40b21f88b6\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Doug Bunting\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022dougbu@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00220994e4e4-d484-4337-a745-54d4db413c14\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Ilya Skuratovsky\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022749f5e71-0fb3-48e1-bcbf-a0b61c8bc426\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\.NET Product Construction Services\\u0022,\\r\\n          \\u0022Vote\\u0022: 0\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 49690,\\r\\n      \\u0022Title\\u0022: \\u0022Upgrade to use .NET 8\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-05-01T23:07:10.8641574Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-05-06T15:12:11.7158588Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/missymessa-upgrade-to-.net8\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022mjanecke@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 49689,\\r\\n      \\u0022Title\\u0022: \\u0022Remove uses of local auth in staging\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-05-01T21:59:10.9646041Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-05-02T22:13:36.1141827Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/janielsen/no-job-sas\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u002269178761-8b3b-61ec-99bb-adddbae2c7d3\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Jakob Botsch Nielsen\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022janielsen@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00224954a309-db5f-67cc-af54-0f1695d4e970\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Juan Sebastian Hoyos Ayala\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022f0c34267-aedb-6a23-8361-271e79fc9284\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Tomas Weinfurt\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 49685,\\r\\n      \\u0022Title\\u0022: \\u0022add queue name to list of machines without heartbeat\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-05-01T19:24:09.5522958Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-05-20T16:33:15.9355767Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/wfurt/qName\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022f0c34267-aedb-6a23-8361-271e79fc9284\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Tomas Weinfurt\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022toweinfu@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 49643,\\r\\n      \\u0022Title\\u0022: \\u0022Updated WorkItem File permalink to account for null/missing logs\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-04-30T07:51:16.7860042Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-05-01T18:47:13.5165894Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/juhoyosa/null-check\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u00224954a309-db5f-67cc-af54-0f1695d4e970\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Juan Sebastian Hoyos Ayala\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022juhoyosa@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u002269178761-8b3b-61ec-99bb-adddbae2c7d3\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Jakob Botsch Nielsen\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 49625,\\r\\n      \\u0022Title\\u0022: \\u0022Handle /console properly for both static files and internal files\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-04-29T19:11:23.7410918Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-05-01T16:26:22.9845389Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/janielsen/console-log-try-3\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u002269178761-8b3b-61ec-99bb-adddbae2c7d3\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Jakob Botsch Nielsen\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022janielsen@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 49590,\\r\\n      \\u0022Title\\u0022: \\u0022Handle Console API for statically hosted files too\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-04-29T09:37:14.6697629Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-04-29T14:53:39.3396069Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/janielsen/console-log-cancelled\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u002269178761-8b3b-61ec-99bb-adddbae2c7d3\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Jakob Botsch Nielsen\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022janielsen@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00229e5742ee-d918-4543-99a1-616b44d67b54\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Ricardo Arenas\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 49547,\\r\\n      \\u0022Title\\u0022: \\u0022Skip permalinks for files from dotnet.github.io\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-04-28T10:05:09.7171247Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-04-28T15:17:34.4248214Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/janielsen/static-file-results\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u002269178761-8b3b-61ec-99bb-adddbae2c7d3\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Jakob Botsch Nielsen\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022janielsen@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 49411,\\r\\n      \\u0022Title\\u0022: \\u0022Return \\\\u0022file permalinks\\\\u0022 for authenticated files from HelixAPI\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-04-23T14:16:12.9247452Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-04-24T18:09:59.8616783Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/janielsen/file-permalinks\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u002269178761-8b3b-61ec-99bb-adddbae2c7d3\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Jakob Botsch Nielsen\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022janielsen@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00229e5742ee-d918-4543-99a1-616b44d67b54\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Ricardo Arenas\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 49395,\\r\\n      \\u0022Title\\u0022: \\u0022Do not truncate text on overflow\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-04-22T23:31:03.6207663Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-04-22T23:54:11.0299812Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/mistucke/6585-queueinfo-a11y-minimum-fix\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022mistucke@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 49333,\\r\\n      \\u0022Title\\u0022: \\u0022Remove Kusto SAS from settings.json\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-04-18T23:40:39.2505344Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-04-19T01:20:17.9955354Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/clean-up\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u002202bcc5bb-1d50-66e4-9b9f-736c0b1329e7\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Epsitha Ananth\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022epananth@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022a84ff60a-5a35-4c3f-8bb9-2e40b21f88b6\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Doug Bunting\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 49247,\\r\\n      \\u0022Title\\u0022: \\u0022Remove SAS from Metrics Observer\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-04-16T18:21:11.0168024Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-04-18T20:59:00.1447245Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/metrics-observer\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u002202bcc5bb-1d50-66e4-9b9f-736c0b1329e7\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Epsitha Ananth\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022epananth@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00229e5742ee-d918-4543-99a1-616b44d67b54\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Ricardo Arenas\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 49204,\\r\\n      \\u0022Title\\u0022: \\u0022Make \\\\u0060packageParentPath\\\\u0060 more specific\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-04-15T10:31:13.5988006Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-04-15T14:28:39.3141682Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/more-specific-packageParentPath\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u002269178761-8b3b-61ec-99bb-adddbae2c7d3\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Jakob Botsch Nielsen\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022janielsen@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00229e5742ee-d918-4543-99a1-616b44d67b54\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Ricardo Arenas\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 49169,\\r\\n      \\u0022Title\\u0022: \\u0022remove organizations we do not have permissions to\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-04-11T22:20:53.4921169Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-04-14T17:21:06.5811844Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/haruna/remove-invalid-organizations\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022b1f55bb3-0f83-65fa-8753-6f328b94345e\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Haruna Ogweda\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022harunaogweda@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00220994e4e4-d484-4337-a745-54d4db413c14\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Ilya Skuratovsky\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00229e5742ee-d918-4543-99a1-616b44d67b54\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Ricardo Arenas\\u0022,\\r\\n          \\u0022Vote\\u0022: 0\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 49164,\\r\\n      \\u0022Title\\u0022: \\u0022Credscan failure during publishing - workaround for ICM 615434079\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-04-11T16:52:58.9254099Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-04-14T22:39:52.4443248Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/meghnave/credscan_failure_workaround\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u002211d4085b-6535-6a6c-a5ef-c87bedeca35e\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Meghna Verma\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022meghnaverma@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022f0c34267-aedb-6a23-8361-271e79fc9284\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Tomas Weinfurt\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1f55bb3-0f83-65fa-8753-6f328b94345e\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Haruna Ogweda\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u002269178761-8b3b-61ec-99bb-adddbae2c7d3\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Jakob Botsch Nielsen\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 49015,\\r\\n      \\u0022Title\\u0022: \\u0022Change Helix to not set \\\\u0060conclusion\\\\u0060 when \\\\u0060status\\\\u0060 is \\\\u0060in_progress\\\\u0060\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-04-08T07:20:46.2020953Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-04-08T19:23:20.4347989Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/use-pending-when-in-progress\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u00222fd97e11-691e-4007-9668-359c4c1b2a92\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Andy Gocke\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022angocke@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00220994e4e4-d484-4337-a745-54d4db413c14\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Ilya Skuratovsky\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u002287d5051d-03bf-42a5-82e6-7be0a9a3678c\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Mark Wilkie\\u0022,\\r\\n          \\u0022Vote\\u0022: 0\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 48682,\\r\\n      \\u0022Title\\u0022: \\u0022Exclude \\\\u0060.cet\\\\u0060 and \\\\u0060.cedarcrest\\\\u0060 queues from an alert\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-03-22T04:17:09.3232599Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-03-24T15:14:02.9030234Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dougbu/svc.alert.5277\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022a84ff60a-5a35-4c3f-8bb9-2e40b21f88b6\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Doug Bunting\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022dougbu@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 48681,\\r\\n      \\u0022Title\\u0022: \\u0022Fix queries used for mobile devices to match grafana alerting\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-03-22T03:21:33.2564381Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-03-24T20:56:49.9057991Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/juhoyosa/add-more-queries-onprem\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u00224954a309-db5f-67cc-af54-0f1695d4e970\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Juan Sebastian Hoyos Ayala\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022juhoyosa@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00220994e4e4-d484-4337-a745-54d4db413c14\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Ilya Skuratovsky\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 48449,\\r\\n      \\u0022Title\\u0022: \\u0022[main] Update dependencies from dotnet/dnceng-shared\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-03-14T05:01:28.048116Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-05-01T17:32:06.4453134Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/darc-main-51fc2a65-8127-4cfe-a029-df85e177776f\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022ProductConstructionServiceProd\\u0022,\\r\\n        \\u0022Email\\u0022: \\u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u002202bcc5bb-1d50-66e4-9b9f-736c0b1329e7\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Epsitha Ananth\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 48348,\\r\\n      \\u0022Title\\u0022: \\u0022Fix UserDb in helixapi uses password\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-03-12T17:00:17.5802335Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-03-13T17:54:56.9619664Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/enji/sql-secrets\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u00226d5d7783-3f68-61b8-ada5-d9af8319d0c8\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Enji Eid\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022enjieid@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00224954a309-db5f-67cc-af54-0f1695d4e970\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Juan Sebastian Hoyos Ayala\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u002202bcc5bb-1d50-66e4-9b9f-736c0b1329e7\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Epsitha Ananth\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 48321,\\r\\n      \\u0022Title\\u0022: \\u0022[main] Update dependencies from dotnet/dnceng\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-03-12T05:01:37.5184443Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-05-01T21:30:31.4134207Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/darc-main-6bedc7ec-4d5c-4c9d-ba9e-022f69a455f9\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022ProductConstructionServiceProd\\u0022,\\r\\n        \\u0022Email\\u0022: \\u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 48303,\\r\\n      \\u0022Title\\u0022: \\u0022Remove unused SQL settings\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-03-11T14:35:20.1263072Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-03-11T19:01:28.1256352Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/enji/sql-fix\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u00226d5d7783-3f68-61b8-ada5-d9af8319d0c8\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Enji Eid\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022enjieid@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 48206,\\r\\n      \\u0022Title\\u0022: \\u0022Remove reference to HelixSigningKV from code\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-03-07T22:39:24.7400183Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-03-12T19:54:32.1702559Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/missymessa-6728\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022mjanecke@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022a84ff60a-5a35-4c3f-8bb9-2e40b21f88b6\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Doug Bunting\\u0022,\\r\\n          \\u0022Vote\\u0022: 0\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022db0724ea-305e-418a-969c-779e49c58ad8\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022David Foster (DEVOPS)\\u0022,\\r\\n          \\u0022Vote\\u0022: 0\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 48203,\\r\\n      \\u0022Title\\u0022: \\u0022Fix AkaMs metrics collector\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-03-07T21:25:11.2690546Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-03-11T21:11:01.5272625Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/mistucke/nnnn-fix-akams-observer\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022mistucke@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225981d0ba-743b-6d84-9319-ec043e802737\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Farhad Alizada\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 48201,\\r\\n      \\u0022Title\\u0022: \\u0022Fix telemetry client initialization in the autoscale actor to use connection...\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-03-07T17:09:49.2074374Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-03-07T21:55:17.7889819Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/riarenas/fix-telemetry\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u00229e5742ee-d918-4543-99a1-616b44d67b54\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Ricardo Arenas\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022riarenas@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 48191,\\r\\n      \\u0022Title\\u0022: \\u0022Merge Production back into main\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-03-07T13:58:29.3088628Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-03-24T16:43:04.7833581Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/production\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u00229e5742ee-d918-4543-99a1-616b44d67b54\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Ricardo Arenas\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022riarenas@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022db0724ea-305e-418a-969c-779e49c58ad8\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022David Foster (DEVOPS)\\u0022,\\r\\n          \\u0022Vote\\u0022: 0\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 0\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 48129,\\r\\n      \\u0022Title\\u0022: \\u0022Add configurable scale factor per queue\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-03-04T23:33:03.4888587Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-03-05T22:14:43.6935959Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/riarenas/add-multiplier\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u00229e5742ee-d918-4543-99a1-616b44d67b54\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Ricardo Arenas\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022riarenas@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 48086,\\r\\n      \\u0022Title\\u0022: \\u0022Add IsExternal Property to StorageContainer table and filter\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-03-03T11:58:24.2702001Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-03-18T09:50:39.7856856Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/falizada/add-is-external\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u00225981d0ba-743b-6d84-9319-ec043e802737\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Farhad Alizada\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022falizada@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 48009,\\r\\n      \\u0022Title\\u0022: \\u0022Deleting package references for removed packages\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-02-27T22:42:01.4058998Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-02-27T23:04:50.7178264Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/missymessa-remove-unused-libs\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022mjanecke@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 47956,\\r\\n      \\u0022Title\\u0022: \\u0022[main] Update dependencies from dotnet/dnceng-shared\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-02-26T05:02:09.7238823Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-03-11T22:22:49.0906142Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/darc-main-50e7ab45-a9eb-424b-bdd4-3283addcfa21\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022ProductConstructionServiceProd\\u0022,\\r\\n        \\u0022Email\\u0022: \\u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 47900,\\r\\n      \\u0022Title\\u0022: \\u0022[main] Update dependencies from dotnet/dnceng\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-02-25T05:01:58.2047265Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-03-12T17:32:37.6182153Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/darc-main-df424632-6f4b-490e-a78c-87b7feb8101f\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022ProductConstructionServiceProd\\u0022,\\r\\n        \\u0022Email\\u0022: \\u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 47871,\\r\\n      \\u0022Title\\u0022: \\u0022remove no needed firewall scripts\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-02-24T15:40:10.7046328Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-02-25T09:29:37.9545755Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/enji/remove-firewall\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u00226d5d7783-3f68-61b8-ada5-d9af8319d0c8\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Enji Eid\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022enjieid@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00229e5742ee-d918-4543-99a1-616b44d67b54\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Ricardo Arenas\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 47870,\\r\\n      \\u0022Title\\u0022: \\u0022use service principal to deploy helix-data\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-02-24T15:38:48.0321501Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-03-05T12:52:46.3584941Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/enji/update-helixdata-deployment\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u00226d5d7783-3f68-61b8-ada5-d9af8319d0c8\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Enji Eid\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022enjieid@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225981d0ba-743b-6d84-9319-ec043e802737\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Farhad Alizada\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 47788,\\r\\n      \\u0022Title\\u0022: \\u0022Add ListOnPremMachinesNeedingHelp tool\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-02-20T06:35:50.1047213Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-02-20T18:24:44.615177Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/juhoyosa/add-onprem-tool\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u00224954a309-db5f-67cc-af54-0f1695d4e970\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Juan Sebastian Hoyos Ayala\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022juhoyosa@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00220994e4e4-d484-4337-a745-54d4db413c14\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Ilya Skuratovsky\\u0022,\\r\\n          \\u0022Vote\\u0022: 0\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 47783,\\r\\n      \\u0022Title\\u0022: \\u0022Remove secrets related to rollout scorer\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-02-19T19:32:43.7261151Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-02-19T21:48:30.5333557Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/missymessa-4658\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022mjanecke@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 47782,\\r\\n      \\u0022Title\\u0022: \\u0022Update DB using service connection\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-02-19T16:36:15.4546495Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-03-05T20:57:41.4054644Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/enji/sql-passwords\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u00226d5d7783-3f68-61b8-ada5-d9af8319d0c8\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Enji Eid\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022enjieid@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 47736,\\r\\n      \\u0022Title\\u0022: \\u0022Pin NuGet restore task version\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-02-18T09:11:21.9732797Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-02-18T17:52:51.2782783Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/janielsen/nuget-restore-task-version\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u002269178761-8b3b-61ec-99bb-adddbae2c7d3\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Jakob Botsch Nielsen\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022janielsen@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00226d5d7783-3f68-61b8-ada5-d9af8319d0c8\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Enji Eid\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 47547,\\r\\n      \\u0022Title\\u0022: \\u0022Introduce the concept of a minCapacity to the autoscale configuration\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-02-12T08:20:21.0285644Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-02-12T23:03:00.4678137Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/riarenas/add-min-scale\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u00229e5742ee-d918-4543-99a1-616b44d67b54\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Ricardo Arenas\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022riarenas@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00220994e4e4-d484-4337-a745-54d4db413c14\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Ilya Skuratovsky\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 0\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 47541,\\r\\n      \\u0022Title\\u0022: \\u0022[main] Update dependencies from dotnet/dnceng-shared\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-02-12T05:01:23.3897556Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-02-21T19:17:50.115608Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/darc-main-4b422bea-8e0b-4a50-a27f-17614ba1ff19\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022ProductConstructionServiceProd\\u0022,\\r\\n        \\u0022Email\\u0022: \\u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 47518,\\r\\n      \\u0022Title\\u0022: \\u0022Upload app package using the Service Principle\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-02-11T17:27:51.5329959Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-02-13T08:19:29.4376482Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/falizada/use-connected-to-upload-package\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u00225981d0ba-743b-6d84-9319-ec043e802737\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Farhad Alizada\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022falizada@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00229e5742ee-d918-4543-99a1-616b44d67b54\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Ricardo Arenas\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 47437,\\r\\n      \\u0022Title\\u0022: \\u0022Add container info to exception\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-02-10T09:14:50.3957555Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-02-11T15:34:47.7729028Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/falizada/add-more-logs-to-exception\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u00225981d0ba-743b-6d84-9319-ec043e802737\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Farhad Alizada\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022falizada@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00229e5742ee-d918-4543-99a1-616b44d67b54\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Ricardo Arenas\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 47427,\\r\\n      \\u0022Title\\u0022: \\u0022[main] Update dependencies from dotnet/dnceng\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-02-08T05:01:57.6461445Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-02-10T20:12:09.4369648Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/darc-main-734e0d1a-e13d-4b10-a16f-2face0e768d2\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022ProductConstructionServiceProd\\u0022,\\r\\n        \\u0022Email\\u0022: \\u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 47318,\\r\\n      \\u0022Title\\u0022: \\u0022Revert \\\\u0022Merged PR 47204: Use the connected account for context\\\\u0022\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-02-04T18:52:05.2514266Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-02-04T19:25:56.5226588Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/falizada/revert-useconnected\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u00225981d0ba-743b-6d84-9319-ec043e802737\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Farhad Alizada\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022falizada@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00229e5742ee-d918-4543-99a1-616b44d67b54\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Ricardo Arenas\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 47291,\\r\\n      \\u0022Title\\u0022: \\u0022Move secret to arcade\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-02-03T17:36:11.7050794Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-02-05T17:11:13.5868459Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/move-secret-to-arcade\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022ab548af8-1ef9-4928-8fd6-2014ea725a67\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Matt Mitchell (.NET)\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022mmitche@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00229e5742ee-d918-4543-99a1-616b44d67b54\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Ricardo Arenas\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 47277,\\r\\n      \\u0022Title\\u0022: \\u0022Merge Production =\\\\u003E main\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-02-01T00:40:27.3179957Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-02-03T17:46:26.5083519Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/production\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022db0724ea-305e-418a-969c-779e49c58ad8\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022David Foster (DEVOPS)\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022davfost@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022a84ff60a-5a35-4c3f-8bb9-2e40b21f88b6\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Doug Bunting\\u0022,\\r\\n          \\u0022Vote\\u0022: 0\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00220994e4e4-d484-4337-a745-54d4db413c14\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Ilya Skuratovsky\\u0022,\\r\\n          \\u0022Vote\\u0022: 0\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00229e5742ee-d918-4543-99a1-616b44d67b54\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Ricardo Arenas\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022db0724ea-305e-418a-969c-779e49c58ad8\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022David Foster (DEVOPS)\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 0\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 47231,\\r\\n      \\u0022Title\\u0022: \\u0022[main] Update dependencies from dotnet/dnceng-shared\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-01-31T05:01:54.0121286Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-02-07T18:36:22.9190846Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/darc-main-8ca33b4a-ad99-42f6-a3a5-89746addef08\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022ProductConstructionServiceProd\\u0022,\\r\\n        \\u0022Email\\u0022: \\u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00224954a309-db5f-67cc-af54-0f1695d4e970\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Juan Sebastian Hoyos Ayala\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00229e5742ee-d918-4543-99a1-616b44d67b54\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Ricardo Arenas\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 47215,\\r\\n      \\u0022Title\\u0022: \\u0022Update autoscale alerts runbook\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-01-30T17:18:38.8911678Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-01-30T19:34:56.8538863Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/meghnave/update_autoscale_runbook\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u002211d4085b-6535-6a6c-a5ef-c87bedeca35e\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Meghna Verma\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022meghnaverma@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00229e5742ee-d918-4543-99a1-616b44d67b54\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Ricardo Arenas\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 47204,\\r\\n      \\u0022Title\\u0022: \\u0022Use the connected account for context\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-01-30T12:14:23.0722448Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-02-03T13:56:08.3562613Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/falizada/upload-apppackage-via-mi\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u00225981d0ba-743b-6d84-9319-ec043e802737\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Farhad Alizada\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022falizada@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00220994e4e4-d484-4337-a745-54d4db413c14\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Ilya Skuratovsky\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u002269178761-8b3b-61ec-99bb-adddbae2c7d3\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Jakob Botsch Nielsen\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 47184,\\r\\n      \\u0022Title\\u0022: \\u0022Deploy production VMSS via templates\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-01-29T18:58:55.7458136Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-01-31T09:59:28.3895124Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/janielsen/vmss-prod-deployment\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u002269178761-8b3b-61ec-99bb-adddbae2c7d3\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Jakob Botsch Nielsen\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022janielsen@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00229e5742ee-d918-4543-99a1-616b44d67b54\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Ricardo Arenas\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225981d0ba-743b-6d84-9319-ec043e802737\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Farhad Alizada\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 47092,\\r\\n      \\u0022Title\\u0022: \\u0022Add secrets to VMSS template\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-01-27T16:22:53.9452003Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-01-29T09:02:34.3534862Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/janielsen/vmss-add-secrets\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u002269178761-8b3b-61ec-99bb-adddbae2c7d3\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Jakob Botsch Nielsen\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022janielsen@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00224954a309-db5f-67cc-af54-0f1695d4e970\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Juan Sebastian Hoyos Ayala\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225981d0ba-743b-6d84-9319-ec043e802737\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Farhad Alizada\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 47017,\\r\\n      \\u0022Title\\u0022: \\u0022Remove IaaSDiagnostics extension from VMSS\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-01-24T11:50:52.9560989Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-02-07T09:59:26.2541625Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/janielsen/vmss-no-diagnostics\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u002269178761-8b3b-61ec-99bb-adddbae2c7d3\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Jakob Botsch Nielsen\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022janielsen@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00224954a309-db5f-67cc-af54-0f1695d4e970\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Juan Sebastian Hoyos Ayala\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225981d0ba-743b-6d84-9319-ec043e802737\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Farhad Alizada\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 47016,\\r\\n      \\u0022Title\\u0022: \\u0022Skip production deployment of VMSS from templates\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-01-24T11:24:37.8719098Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-01-24T17:01:26.3473903Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/janielsen/vmss-skip-prod-deployment\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u002269178761-8b3b-61ec-99bb-adddbae2c7d3\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Jakob Botsch Nielsen\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022janielsen@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00229e5742ee-d918-4543-99a1-616b44d67b54\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Ricardo Arenas\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225981d0ba-743b-6d84-9319-ec043e802737\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Farhad Alizada\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 46990,\\r\\n      \\u0022Title\\u0022: \\u0022[Service Fabric] Update auth type of downloading file in VMSS during the provision\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-01-23T12:26:26.1730524Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-02-06T21:46:17.9297365Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/enji/Use-MI-with-CustomScriptextension\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u00226d5d7783-3f68-61b8-ada5-d9af8319d0c8\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Enji Eid\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022enjieid@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u002269178761-8b3b-61ec-99bb-adddbae2c7d3\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Jakob Botsch Nielsen\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225981d0ba-743b-6d84-9319-ec043e802737\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Farhad Alizada\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 46955,\\r\\n      \\u0022Title\\u0022: \\u0022Add a bicep template for VMSS deployment\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-01-22T11:11:51.0116823Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-01-23T09:50:12.9339469Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/janielsen/vmss-bicep-template\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u002269178761-8b3b-61ec-99bb-adddbae2c7d3\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Jakob Botsch Nielsen\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022janielsen@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022da8e23bb-3123-4efe-9074-87b88acf60b7\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Christopher Costa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225981d0ba-743b-6d84-9319-ec043e802737\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Farhad Alizada\\u0022,\\r\\n          \\u0022Vote\\u0022: 0\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 46779,\\r\\n      \\u0022Title\\u0022: \\u0022Update Diagnostics fabricSettings to use MI \\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-01-16T08:49:56.3240542Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-01-17T09:53:15.1059845Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/falizada/update-sf-diag-settings\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u00225981d0ba-743b-6d84-9319-ec043e802737\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Farhad Alizada\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022falizada@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 46728,\\r\\n      \\u0022Title\\u0022: \\u0022[main] Update dependencies from dotnet/dnceng\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-01-15T05:02:16.7546254Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-02-07T18:05:44.1185076Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/darc-main-55f48001-2cea-4232-b4e8-c74a543fc14c\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022ProductConstructionServiceProd\\u0022,\\r\\n        \\u0022Email\\u0022: \\u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 46724,\\r\\n      \\u0022Title\\u0022: \\u0022Revert 1ES PT Release Tasks bits\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-01-14T21:47:27.8375603Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-01-14T23:38:51.1316292Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/mistucke/4311-revert-release-tasks\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022mistucke@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00224954a309-db5f-67cc-af54-0f1695d4e970\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Juan Sebastian Hoyos Ayala\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 46597,\\r\\n      \\u0022Title\\u0022: \\u0022Fixup some additional wayward release tasks\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-01-09T00:07:27.6442168Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-01-09T00:40:20.2152017Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/mistucke/4311-part-2\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022mistucke@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022ab548af8-1ef9-4928-8fd6-2014ea725a67\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Matt Mitchell (.NET)\\u0022,\\r\\n          \\u0022Vote\\u0022: 0\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 46560,\\r\\n      \\u0022Title\\u0022: \\u0022[main] Update dependencies from dotnet/dnceng\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-01-08T05:01:31.4054157Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-01-09T00:49:44.5612699Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/darc-main-8b354566-3a5b-4686-a409-7f4ccebe8607\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022ProductConstructionServiceProd\\u0022,\\r\\n        \\u0022Email\\u0022: \\u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 46555,\\r\\n      \\u0022Title\\u0022: \\u0022Update helix-admin list to account for team member changes\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-01-07T22:06:42.9653773Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-01-08T19:07:03.3624483Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/meghnave/update-helix-admin-list\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u002211d4085b-6535-6a6c-a5ef-c87bedeca35e\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Meghna Verma\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022meghnaverma@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022a84ff60a-5a35-4c3f-8bb9-2e40b21f88b6\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Doug Bunting\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 46488,\\r\\n      \\u0022Title\\u0022: \\u0022[main] Update dependencies from dotnet/dnceng\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-01-04T05:01:35.097041Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-01-07T19:35:37.4754765Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/darc-main-76f7b805-c38c-4cc7-b5ba-76672da4638d\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022ProductConstructionServiceProd\\u0022,\\r\\n        \\u0022Email\\u0022: \\u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 46487,\\r\\n      \\u0022Title\\u0022: \\u0022[main] Update dependencies from dotnet/dnceng-shared\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-01-04T05:01:33.3783Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-01-07T22:56:11.4928266Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/darc-main-0807d97e-2619-4051-9db0-32344f2c2259\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022ProductConstructionServiceProd\\u0022,\\r\\n        \\u0022Email\\u0022: \\u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1f55bb3-0f83-65fa-8753-6f328b94345e\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Haruna Ogweda\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022db0724ea-305e-418a-969c-779e49c58ad8\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022David Foster (DEVOPS)\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 46460,\\r\\n      \\u0022Title\\u0022: \\u0022[main] Update dependencies from dotnet/dnceng-shared\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222025-01-03T05:01:32.6142276Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-01-03T21:46:53.841062Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/darc-main-8987be80-f88f-4fad-a529-9a356673d812\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022ProductConstructionServiceProd\\u0022,\\r\\n        \\u0022Email\\u0022: \\u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 46410,\\r\\n      \\u0022Title\\u0022: \\u0022Use release jobs in the deployment stage\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222024-12-31T18:39:56.7021672Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-01-08T23:33:06.4321581Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/use-release-job\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022ab548af8-1ef9-4928-8fd6-2014ea725a67\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Matt Mitchell (.NET)\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022mmitche@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 46041,\\r\\n      \\u0022Title\\u0022: \\u0022[main] Update dependencies from dotnet/dnceng\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222024-12-14T13:30:11.9752581Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222024-12-30T22:45:43.6574181Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/darc-main-ac6fc9f7-a6ab-4a93-98be-229a4b20bf3f\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022e247ef8c-b6cf-6ca6-9c94-5a3a9c583c07\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022maestro-prod-Primary\\u0022,\\r\\n        \\u0022Email\\u0022: \\u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\\\\\610d53f3-8c41-42a0-9941-cb44eecfa176\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 45847,\\r\\n      \\u0022Title\\u0022: \\u0022Rolling back the Azure.Identity nuget to version 1.12.1\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222024-12-10T21:13:08.3492333Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222024-12-10T21:40:15.1687517Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/davfost/20241210_BuildFailure\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022db0724ea-305e-418a-969c-779e49c58ad8\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022David Foster (DEVOPS)\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022davfost@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00220994e4e4-d484-4337-a745-54d4db413c14\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Ilya Skuratovsky\\u0022,\\r\\n          \\u0022Vote\\u0022: 0\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00229e5742ee-d918-4543-99a1-616b44d67b54\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Ricardo Arenas\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1f55bb3-0f83-65fa-8753-6f328b94345e\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Haruna Ogweda\\u0022,\\r\\n          \\u0022Vote\\u0022: 0\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022db0724ea-305e-418a-969c-779e49c58ad8\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022David Foster (DEVOPS)\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 0\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 45732,\\r\\n      \\u0022Title\\u0022: \\u0022[main] Update dependencies from dotnet/dnceng-shared\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222024-12-06T13:32:25.7109131Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222024-12-31T19:38:51.2624596Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/darc-main-721fdaea-5294-48f8-9562-9d185cdeb680\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022e247ef8c-b6cf-6ca6-9c94-5a3a9c583c07\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022maestro-prod-Primary\\u0022,\\r\\n        \\u0022Email\\u0022: \\u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\\\\\610d53f3-8c41-42a0-9941-cb44eecfa176\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022a84ff60a-5a35-4c3f-8bb9-2e40b21f88b6\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Doug Bunting\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 45631,\\r\\n      \\u0022Title\\u0022: \\u0022Look for AzDO issues in PRs as well as GitHub issues\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222024-12-03T19:01:18.0068558Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222024-12-04T16:17:50.4413523Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/missymessa-7191\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022mjanecke@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022a84ff60a-5a35-4c3f-8bb9-2e40b21f88b6\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Doug Bunting\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 45421,\\r\\n      \\u0022Title\\u0022: \\u0022enable PoliCheck and TSA in dotnet-helix-service-ci pipeline\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222024-11-26T23:56:40.6679543Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222024-12-04T18:50:40.3601945Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/haruna/tsa-compliance\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022b1f55bb3-0f83-65fa-8753-6f328b94345e\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Haruna Ogweda\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022harunaogweda@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00229e5742ee-d918-4543-99a1-616b44d67b54\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Ricardo Arenas\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 45191,\\r\\n      \\u0022Title\\u0022: \\u0022[SECURITY] Bump System.Text.Json from 8.0.4 to 8.0.5 in /src\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222024-11-21T05:08:39.885722Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222024-11-22T18:55:10.3892846Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dependabot/nuget/src/System.Text.Json-8.0.5-71988\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u002200000072-0000-8888-8000-000000000000\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Dependabot\\u0022,\\r\\n        \\u0022Email\\u0022: \\u002200000072-0000-8888-8000-000000000000@2c895908-04e0-4952-89fd-54b0046d6288\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00229e5742ee-d918-4543-99a1-616b44d67b54\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Ricardo Arenas\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 45159,\\r\\n      \\u0022Title\\u0022: \\u0022[A11y] Use underline text style instead of \\\\u003Cu\\\\u003E tags\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222024-11-20T16:03:12.274834Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222024-11-20T17:07:25.1680961Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/riarenas/fix-underline-styling\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u00229e5742ee-d918-4543-99a1-616b44d67b54\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Ricardo Arenas\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022riarenas@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00220994e4e4-d484-4337-a745-54d4db413c14\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Ilya Skuratovsky\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 44959,\\r\\n      \\u0022Title\\u0022: \\u0022Post-deployment merge of the production branch back to main branch\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222024-11-13T21:46:24.9229245Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222024-11-13T22:11:13.3140566Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/production\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022db0724ea-305e-418a-969c-779e49c58ad8\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022David Foster (DEVOPS)\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022davfost@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00229e5742ee-d918-4543-99a1-616b44d67b54\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Ricardo Arenas\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022db0724ea-305e-418a-969c-779e49c58ad8\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022David Foster (DEVOPS)\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 44946,\\r\\n      \\u0022Title\\u0022: \\u0022Move the definition SF cluster from Azure Portal to bicep template\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222024-11-13T14:13:36.7115174Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222025-01-03T10:06:46.1705853Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/falizada/service-fabric-deployment\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u00225981d0ba-743b-6d84-9319-ec043e802737\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Farhad Alizada\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022falizada@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022a84ff60a-5a35-4c3f-8bb9-2e40b21f88b6\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Doug Bunting\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00220994e4e4-d484-4337-a745-54d4db413c14\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Ilya Skuratovsky\\u0022,\\r\\n          \\u0022Vote\\u0022: 0\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 44833,\\r\\n      \\u0022Title\\u0022: \\u0022Fix passing rsas and wsas to JobCreationRequest\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222024-11-08T15:37:31.5536539Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222024-11-09T09:14:54.4437741Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/srozsival/fix-job-creation-request-wsas\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u002214b37c7b-4c51-6bd6-b73e-63b8a6db0616\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Simon Rozsival\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022srozsival@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225981d0ba-743b-6d84-9319-ec043e802737\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Farhad Alizada\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 44832,\\r\\n      \\u0022Title\\u0022: \\u0022Remove the creation of resource group functionality in Storage account creation\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222024-11-08T14:20:00.4426464Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222024-11-11T12:23:10.8107106Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/falizada/remove-resource-group-creation-deprecate\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u00225981d0ba-743b-6d84-9319-ec043e802737\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Farhad Alizada\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022falizada@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Missy Messa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 44604,\\r\\n      \\u0022Title\\u0022: \\u0022Disable shared key access for newly created storage accounts in tests\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222024-11-04T12:00:51.9065535Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222024-11-23T12:02:19.1816901Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/dev/srozsival/disable-shared-key-access-to-storage-accounts-created-by-azure-resource-helper\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u002214b37c7b-4c51-6bd6-b73e-63b8a6db0616\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022Simon Rozsival\\u0022,\\r\\n        \\u0022Email\\u0022: \\u0022srozsival@microsoft.com\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022da8e23bb-3123-4efe-9074-87b88acf60b7\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Christopher Costa\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225981d0ba-743b-6d84-9319-ec043e802737\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Farhad Alizada\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    },\\r\\n    {\\r\\n      \\u0022PullRequestId\\u0022: 44473,\\r\\n      \\u0022Title\\u0022: \\u0022[main] Update dependencies from dotnet/dnceng\\u0022,\\r\\n      \\u0022Status\\u0022: 3,\\r\\n      \\u0022CreationDate\\u0022: \\u00222024-10-29T12:10:05.5418871Z\\u0022,\\r\\n      \\u0022ClosedDate\\u0022: \\u00222024-12-14T01:35:52.9836523Z\\u0022,\\r\\n      \\u0022SourceRefName\\u0022: \\u0022refs/heads/darc-main-7e587618-7db1-422f-9f2f-c9fdce65b50b\\u0022,\\r\\n      \\u0022TargetRefName\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n      \\u0022Creator\\u0022: {\\r\\n        \\u0022Id\\u0022: \\u0022e247ef8c-b6cf-6ca6-9c94-5a3a9c583c07\\u0022,\\r\\n        \\u0022Name\\u0022: \\u0022maestro-prod-Primary\\u0022,\\r\\n        \\u0022Email\\u0022: \\u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\\\\\610d53f3-8c41-42a0-9941-cb44eecfa176\\u0022\\r\\n      },\\r\\n      \\u0022Reviewers\\u0022: [\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u00225d578427-4dda-426c-8212-0760e978f0ab\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022[TEAM FOUNDATION]\\\\\\\\MaWilkie\\\\u0027s Direct Reports\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        },\\r\\n        {\\r\\n          \\u0022Id\\u0022: \\u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\\u0022,\\r\\n          \\u0022Name\\u0022: \\u0022Michael Stuckey\\u0022,\\r\\n          \\u0022Vote\\u0022: 10\\r\\n        }\\r\\n      ]\\r\\n    }\\r\\n  ]\\r\\n}\u0022}]}",
  "parsed_results": {
    "content": {
      "items": [
        {
          "type": "text",
          "text": "{\r\n  \u0022TotalCount\u0022: 101,\r\n  \u0022FilteredBy\u0022: {\r\n    \u0022Status\u0022: \u0022completed\u0022,\r\n    \u0022TargetBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022TimeRangeType\u0022: \u0022closed\u0022,\r\n    \u0022BeforeClosedDate\u0022: \u00222025-07-01 00:00:00\u0022,\r\n    \u0022AfterClosedDate\u0022: null,\r\n    \u0022MaxResults\u0022: null\r\n  },\r\n  \u0022PullRequests\u0022: [\r\n    {\r\n      \u0022PullRequestId\u0022: 51170,\r\n      \u0022Title\u0022: \u0022A11y fixes for banner landmark\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-06-25T22:22:21.3719358Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-06-26T21:10:01.55478Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/missymessa-7877\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n        \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n        \u0022Email\u0022: \u0022mjanecke@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022f0c34267-aedb-6a23-8361-271e79fc9284\u0022,\r\n          \u0022Name\u0022: \u0022Tomas Weinfurt\u0022,\r\n          \u0022Vote\u0022: 0\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 51079,\r\n      \u0022Title\u0022: \u0022[main] Update dependencies from dotnet/dnceng\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-06-20T02:01:52.7923941Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-06-20T21:39:28.5070141Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/darc-main-0936e357-3e68-4f96-b5ef-4aaa9acaaa2c\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\u0022,\r\n        \u0022Name\u0022: \u0022ProductConstructionServiceProd\u0022,\r\n        \u0022Email\u0022: \u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n          \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 50933,\r\n      \u0022Title\u0022: \u0022Remove Kusto SAS reference\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-06-16T22:22:08.2524857Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-06-18T23:01:11.6018651Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/removeKusto\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u002202bcc5bb-1d50-66e4-9b9f-736c0b1329e7\u0022,\r\n        \u0022Name\u0022: \u0022Epsitha Ananth\u0022,\r\n        \u0022Email\u0022: \u0022epananth@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n          \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 50794,\r\n      \u0022Title\u0022: \u0022Fix missing images in Build Analysis checks\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-06-12T10:37:02.0639165Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-06-12T16:10:51.9518503Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/alkpli/images\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022abd4b441-4b86-457c-a2d9-e09243ccd846\u0022,\r\n        \u0022Name\u0022: \u0022Alexander K\\u00F6plinger\u0022,\r\n        \u0022Email\u0022: \u0022alkpli@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n          \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 50697,\r\n      \u0022Title\u0022: \u0022[main] Update dependencies from dotnet/dnceng-shared\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-06-07T02:01:09.277749Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-06-18T05:38:03.8992942Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/darc-main-f1df5d2d-38d8-4da1-b262-9526fbb86732\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\u0022,\r\n        \u0022Name\u0022: \u0022ProductConstructionServiceProd\u0022,\r\n        \u0022Email\u0022: \u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 50691,\r\n      \u0022Title\u0022: \u0022Refactor Helix Service to use AwesomeAssertions 9.0.0\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-06-06T16:28:01.6786592Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-06-06T18:45:44.8118992Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/missymessa-5408\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n        \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n        \u0022Email\u0022: \u0022mjanecke@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022db0724ea-305e-418a-969c-779e49c58ad8\u0022,\r\n          \u0022Name\u0022: \u0022David Foster (DEVOPS)\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 50688,\r\n      \u0022Title\u0022: \u0022Merge back production -\\u003E main 06-06-2025\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-06-06T16:15:40.375998Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-06-06T16:39:56.934887Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/production\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022db0724ea-305e-418a-969c-779e49c58ad8\u0022,\r\n        \u0022Name\u0022: \u0022David Foster (DEVOPS)\u0022,\r\n        \u0022Email\u0022: \u0022davfost@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022f0c34267-aedb-6a23-8361-271e79fc9284\u0022,\r\n          \u0022Name\u0022: \u0022Tomas Weinfurt\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022db0724ea-305e-418a-969c-779e49c58ad8\u0022,\r\n          \u0022Name\u0022: \u0022David Foster (DEVOPS)\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 50640,\r\n      \u0022Title\u0022: \u0022Update deployment steps to be a \\u0022release\\u0022 job\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-06-04T21:38:28.4782363Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-06-30T18:22:06.304234Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/chcosta/refactor-release\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022da8e23bb-3123-4efe-9074-87b88acf60b7\u0022,\r\n        \u0022Name\u0022: \u0022Christopher Costa\u0022,\r\n        \u0022Email\u0022: \u0022chcosta@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 50605,\r\n      \u0022Title\u0022: \u0022Refactor EventHub in Helix Service to use modern Azure SDK\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-06-03T22:55:48.0565253Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-06-13T20:41:15.6244576Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/missymessa-893\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n        \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n        \u0022Email\u0022: \u0022mjanecke@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 50532,\r\n      \u0022Title\u0022: \u0022[main] Update dependencies from dotnet/dnceng\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-06-01T02:01:42.794294Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-06-04T14:22:25.9775097Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/darc-main-064daa12-c6d5-4af9-984f-b55b36d1370d\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\u0022,\r\n        \u0022Name\u0022: \u0022ProductConstructionServiceProd\u0022,\r\n        \u0022Email\u0022: \u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n          \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 50520,\r\n      \u0022Title\u0022: \u0022[main] Update dependencies from dotnet/dnceng-shared\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-05-31T02:02:05.8997475Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-06-05T19:28:34.4872958Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/darc-main-54aec916-b41f-470d-9a32-3dac1d7d0b31\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\u0022,\r\n        \u0022Name\u0022: \u0022ProductConstructionServiceProd\u0022,\r\n        \u0022Email\u0022: \u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n          \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 50412,\r\n      \u0022Title\u0022: \u0022Add TimeProvider singleton for GitHubAppTokenProvider DI change in Microsoft....\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-05-27T17:37:35.1648798Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-05-27T22:59:54.6132404Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/chcosta/timeprovider-update\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022da8e23bb-3123-4efe-9074-87b88acf60b7\u0022,\r\n        \u0022Name\u0022: \u0022Christopher Costa\u0022,\r\n        \u0022Email\u0022: \u0022chcosta@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n          \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 50394,\r\n      \u0022Title\u0022: \u0022Update Dnceng team members.\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-05-26T12:17:27.1842241Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-05-27T16:53:53.0099128Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/ondrejsmid/update-dncengteam-members\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022a8ab78a9-2d24-67a5-8426-61435ee7fb35\u0022,\r\n        \u0022Name\u0022: \u0022Ondrej Smid\u0022,\r\n        \u0022Email\u0022: \u0022ondrejsmid@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n          \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 50301,\r\n      \u0022Title\u0022: \u0022Refactored Helix Service to use Azure.Messaging.Service instead of Microsoft.Azure.ServiceBus\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-05-21T22:36:20.6015957Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-06-02T15:17:52.7673921Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/missymessa-refactor-servicebus-libs\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n        \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n        \u0022Email\u0022: \u0022mjanecke@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022db0724ea-305e-418a-969c-779e49c58ad8\u0022,\r\n          \u0022Name\u0022: \u0022David Foster (DEVOPS)\u0022,\r\n          \u0022Vote\u0022: 0\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022da8e23bb-3123-4efe-9074-87b88acf60b7\u0022,\r\n          \u0022Name\u0022: \u0022Christopher Costa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 50228,\r\n      \u0022Title\u0022: \u0022[main] Update dependencies from dotnet/dnceng\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-05-20T02:02:08.8576677Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-05-28T15:02:13.9773006Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/darc-main-b8f45194-9b8d-4fbd-bdcb-a10962bc497c\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\u0022,\r\n        \u0022Name\u0022: \u0022ProductConstructionServiceProd\u0022,\r\n        \u0022Email\u0022: \u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n          \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 50221,\r\n      \u0022Title\u0022: \u0022Remove unused namespaces\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-05-20T00:07:07.2843314Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-05-20T00:34:50.0213297Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/missymessa-888\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n        \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n        \u0022Email\u0022: \u0022mjanecke@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 50210,\r\n      \u0022Title\u0022: \u0022Removed unused variables\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-05-19T23:07:05.6846678Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-05-19T23:38:08.8599568Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/missymessa-887\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n        \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n        \u0022Email\u0022: \u0022mjanecke@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 50132,\r\n      \u0022Title\u0022: \u0022Merge back production -\\u003E main 05-16-2025\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-05-16T16:24:00.6987162Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-05-16T17:04:34.4224333Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/production\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022db0724ea-305e-418a-969c-779e49c58ad8\u0022,\r\n        \u0022Name\u0022: \u0022David Foster (DEVOPS)\u0022,\r\n        \u0022Email\u0022: \u0022davfost@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022db0724ea-305e-418a-969c-779e49c58ad8\u0022,\r\n          \u0022Name\u0022: \u0022David Foster (DEVOPS)\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 50088,\r\n      \u0022Title\u0022: \u0022Remove former teammates\\u0027 aliases from Startup.Auth.cs\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-05-15T20:52:09.9700697Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-05-16T22:32:51.0194763Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/missymessa-remove-former-teammates\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n        \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n        \u0022Email\u0022: \u0022mjanecke@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00224954a309-db5f-67cc-af54-0f1695d4e970\u0022,\r\n          \u0022Name\u0022: \u0022Juan Sebastian Hoyos Ayala\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u002211d4085b-6535-6a6c-a5ef-c87bedeca35e\u0022,\r\n          \u0022Name\u0022: \u0022Meghna Verma\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 49940,\r\n      \u0022Title\u0022: \u0022Return azure storage links from listfiles API\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-05-09T16:40:22.6396076Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-05-09T18:02:08.4775139Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/janielsen/listfiles-azure-urls\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u002269178761-8b3b-61ec-99bb-adddbae2c7d3\u0022,\r\n        \u0022Name\u0022: \u0022Jakob Botsch Nielsen\u0022,\r\n        \u0022Email\u0022: \u0022janielsen@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u002202bcc5bb-1d50-66e4-9b9f-736c0b1329e7\u0022,\r\n          \u0022Name\u0022: \u0022Epsitha Ananth\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 49870,\r\n      \u0022Title\u0022: \u0022[main] Update dependencies from dotnet/dnceng-shared\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-05-08T02:01:51.4631398Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-05-19T22:04:01.6617426Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/darc-main-4a7d0498-b0ff-4014-bee7-211a19b7d337\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\u0022,\r\n        \u0022Name\u0022: \u0022ProductConstructionServiceProd\u0022,\r\n        \u0022Email\u0022: \u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1f55bb3-0f83-65fa-8753-6f328b94345e\u0022,\r\n          \u0022Name\u0022: \u0022Haruna Ogweda\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 0\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 49821,\r\n      \u0022Title\u0022: \u0022[main] Update dependencies from dotnet/dnceng\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-05-07T02:01:32.5976291Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-05-16T22:33:38.1911325Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/darc-main-b41dc460-4e9c-457a-85aa-4dc74a7684e9\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\u0022,\r\n        \u0022Name\u0022: \u0022ProductConstructionServiceProd\u0022,\r\n        \u0022Email\u0022: \u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 49817,\r\n      \u0022Title\u0022: \u0022Update YAML to use .NET 8\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-05-06T21:31:00.5763498Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-05-07T17:42:25.1494838Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/missymessa-2412\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n        \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n        \u0022Email\u0022: \u0022mjanecke@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022a84ff60a-5a35-4c3f-8bb9-2e40b21f88b6\u0022,\r\n          \u0022Name\u0022: \u0022Doug Bunting\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 49811,\r\n      \u0022Title\u0022: \u0022Switch user delegation SAS to use HelixStorageHelper._isExternal\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-05-06T16:10:30.1754256Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-05-06T20:03:16.7611772Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/janielsen/no-sas-public\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u002269178761-8b3b-61ec-99bb-adddbae2c7d3\u0022,\r\n        \u0022Name\u0022: \u0022Jakob Botsch Nielsen\u0022,\r\n        \u0022Email\u0022: \u0022janielsen@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n          \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 49727,\r\n      \u0022Title\u0022: \u0022Remove old admins\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-05-04T18:31:17.5815119Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-05-05T16:16:41.8249007Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dougbu/quick.admin.cleanup.5534\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022a84ff60a-5a35-4c3f-8bb9-2e40b21f88b6\u0022,\r\n        \u0022Name\u0022: \u0022Doug Bunting\u0022,\r\n        \u0022Email\u0022: \u0022dougbu@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00220994e4e4-d484-4337-a745-54d4db413c14\u0022,\r\n          \u0022Name\u0022: \u0022Ilya Skuratovsky\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022749f5e71-0fb3-48e1-bcbf-a0b61c8bc426\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\.NET Product Construction Services\u0022,\r\n          \u0022Vote\u0022: 0\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 49690,\r\n      \u0022Title\u0022: \u0022Upgrade to use .NET 8\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-05-01T23:07:10.8641574Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-05-06T15:12:11.7158588Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/missymessa-upgrade-to-.net8\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n        \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n        \u0022Email\u0022: \u0022mjanecke@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 49689,\r\n      \u0022Title\u0022: \u0022Remove uses of local auth in staging\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-05-01T21:59:10.9646041Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-05-02T22:13:36.1141827Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/janielsen/no-job-sas\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u002269178761-8b3b-61ec-99bb-adddbae2c7d3\u0022,\r\n        \u0022Name\u0022: \u0022Jakob Botsch Nielsen\u0022,\r\n        \u0022Email\u0022: \u0022janielsen@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00224954a309-db5f-67cc-af54-0f1695d4e970\u0022,\r\n          \u0022Name\u0022: \u0022Juan Sebastian Hoyos Ayala\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022f0c34267-aedb-6a23-8361-271e79fc9284\u0022,\r\n          \u0022Name\u0022: \u0022Tomas Weinfurt\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n          \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 49685,\r\n      \u0022Title\u0022: \u0022add queue name to list of machines without heartbeat\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-05-01T19:24:09.5522958Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-05-20T16:33:15.9355767Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/wfurt/qName\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022f0c34267-aedb-6a23-8361-271e79fc9284\u0022,\r\n        \u0022Name\u0022: \u0022Tomas Weinfurt\u0022,\r\n        \u0022Email\u0022: \u0022toweinfu@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 49643,\r\n      \u0022Title\u0022: \u0022Updated WorkItem File permalink to account for null/missing logs\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-04-30T07:51:16.7860042Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-05-01T18:47:13.5165894Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/juhoyosa/null-check\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u00224954a309-db5f-67cc-af54-0f1695d4e970\u0022,\r\n        \u0022Name\u0022: \u0022Juan Sebastian Hoyos Ayala\u0022,\r\n        \u0022Email\u0022: \u0022juhoyosa@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n          \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u002269178761-8b3b-61ec-99bb-adddbae2c7d3\u0022,\r\n          \u0022Name\u0022: \u0022Jakob Botsch Nielsen\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 49625,\r\n      \u0022Title\u0022: \u0022Handle /console properly for both static files and internal files\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-04-29T19:11:23.7410918Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-05-01T16:26:22.9845389Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/janielsen/console-log-try-3\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u002269178761-8b3b-61ec-99bb-adddbae2c7d3\u0022,\r\n        \u0022Name\u0022: \u0022Jakob Botsch Nielsen\u0022,\r\n        \u0022Email\u0022: \u0022janielsen@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n          \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 49590,\r\n      \u0022Title\u0022: \u0022Handle Console API for statically hosted files too\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-04-29T09:37:14.6697629Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-04-29T14:53:39.3396069Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/janielsen/console-log-cancelled\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u002269178761-8b3b-61ec-99bb-adddbae2c7d3\u0022,\r\n        \u0022Name\u0022: \u0022Jakob Botsch Nielsen\u0022,\r\n        \u0022Email\u0022: \u0022janielsen@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00229e5742ee-d918-4543-99a1-616b44d67b54\u0022,\r\n          \u0022Name\u0022: \u0022Ricardo Arenas\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 49547,\r\n      \u0022Title\u0022: \u0022Skip permalinks for files from dotnet.github.io\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-04-28T10:05:09.7171247Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-04-28T15:17:34.4248214Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/janielsen/static-file-results\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u002269178761-8b3b-61ec-99bb-adddbae2c7d3\u0022,\r\n        \u0022Name\u0022: \u0022Jakob Botsch Nielsen\u0022,\r\n        \u0022Email\u0022: \u0022janielsen@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n          \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 49411,\r\n      \u0022Title\u0022: \u0022Return \\u0022file permalinks\\u0022 for authenticated files from HelixAPI\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-04-23T14:16:12.9247452Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-04-24T18:09:59.8616783Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/janielsen/file-permalinks\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u002269178761-8b3b-61ec-99bb-adddbae2c7d3\u0022,\r\n        \u0022Name\u0022: \u0022Jakob Botsch Nielsen\u0022,\r\n        \u0022Email\u0022: \u0022janielsen@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00229e5742ee-d918-4543-99a1-616b44d67b54\u0022,\r\n          \u0022Name\u0022: \u0022Ricardo Arenas\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n          \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 49395,\r\n      \u0022Title\u0022: \u0022Do not truncate text on overflow\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-04-22T23:31:03.6207663Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-04-22T23:54:11.0299812Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/mistucke/6585-queueinfo-a11y-minimum-fix\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n        \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n        \u0022Email\u0022: \u0022mistucke@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n          \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 49333,\r\n      \u0022Title\u0022: \u0022Remove Kusto SAS from settings.json\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-04-18T23:40:39.2505344Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-04-19T01:20:17.9955354Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/clean-up\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u002202bcc5bb-1d50-66e4-9b9f-736c0b1329e7\u0022,\r\n        \u0022Name\u0022: \u0022Epsitha Ananth\u0022,\r\n        \u0022Email\u0022: \u0022epananth@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022a84ff60a-5a35-4c3f-8bb9-2e40b21f88b6\u0022,\r\n          \u0022Name\u0022: \u0022Doug Bunting\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 49247,\r\n      \u0022Title\u0022: \u0022Remove SAS from Metrics Observer\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-04-16T18:21:11.0168024Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-04-18T20:59:00.1447245Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/metrics-observer\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u002202bcc5bb-1d50-66e4-9b9f-736c0b1329e7\u0022,\r\n        \u0022Name\u0022: \u0022Epsitha Ananth\u0022,\r\n        \u0022Email\u0022: \u0022epananth@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00229e5742ee-d918-4543-99a1-616b44d67b54\u0022,\r\n          \u0022Name\u0022: \u0022Ricardo Arenas\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n          \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 49204,\r\n      \u0022Title\u0022: \u0022Make \\u0060packageParentPath\\u0060 more specific\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-04-15T10:31:13.5988006Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-04-15T14:28:39.3141682Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/more-specific-packageParentPath\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u002269178761-8b3b-61ec-99bb-adddbae2c7d3\u0022,\r\n        \u0022Name\u0022: \u0022Jakob Botsch Nielsen\u0022,\r\n        \u0022Email\u0022: \u0022janielsen@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00229e5742ee-d918-4543-99a1-616b44d67b54\u0022,\r\n          \u0022Name\u0022: \u0022Ricardo Arenas\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 49169,\r\n      \u0022Title\u0022: \u0022remove organizations we do not have permissions to\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-04-11T22:20:53.4921169Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-04-14T17:21:06.5811844Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/haruna/remove-invalid-organizations\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022b1f55bb3-0f83-65fa-8753-6f328b94345e\u0022,\r\n        \u0022Name\u0022: \u0022Haruna Ogweda\u0022,\r\n        \u0022Email\u0022: \u0022harunaogweda@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00220994e4e4-d484-4337-a745-54d4db413c14\u0022,\r\n          \u0022Name\u0022: \u0022Ilya Skuratovsky\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00229e5742ee-d918-4543-99a1-616b44d67b54\u0022,\r\n          \u0022Name\u0022: \u0022Ricardo Arenas\u0022,\r\n          \u0022Vote\u0022: 0\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 49164,\r\n      \u0022Title\u0022: \u0022Credscan failure during publishing - workaround for ICM 615434079\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-04-11T16:52:58.9254099Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-04-14T22:39:52.4443248Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/meghnave/credscan_failure_workaround\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u002211d4085b-6535-6a6c-a5ef-c87bedeca35e\u0022,\r\n        \u0022Name\u0022: \u0022Meghna Verma\u0022,\r\n        \u0022Email\u0022: \u0022meghnaverma@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022f0c34267-aedb-6a23-8361-271e79fc9284\u0022,\r\n          \u0022Name\u0022: \u0022Tomas Weinfurt\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1f55bb3-0f83-65fa-8753-6f328b94345e\u0022,\r\n          \u0022Name\u0022: \u0022Haruna Ogweda\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u002269178761-8b3b-61ec-99bb-adddbae2c7d3\u0022,\r\n          \u0022Name\u0022: \u0022Jakob Botsch Nielsen\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 49015,\r\n      \u0022Title\u0022: \u0022Change Helix to not set \\u0060conclusion\\u0060 when \\u0060status\\u0060 is \\u0060in_progress\\u0060\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-04-08T07:20:46.2020953Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-04-08T19:23:20.4347989Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/use-pending-when-in-progress\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u00222fd97e11-691e-4007-9668-359c4c1b2a92\u0022,\r\n        \u0022Name\u0022: \u0022Andy Gocke\u0022,\r\n        \u0022Email\u0022: \u0022angocke@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00220994e4e4-d484-4337-a745-54d4db413c14\u0022,\r\n          \u0022Name\u0022: \u0022Ilya Skuratovsky\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u002287d5051d-03bf-42a5-82e6-7be0a9a3678c\u0022,\r\n          \u0022Name\u0022: \u0022Mark Wilkie\u0022,\r\n          \u0022Vote\u0022: 0\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 48682,\r\n      \u0022Title\u0022: \u0022Exclude \\u0060.cet\\u0060 and \\u0060.cedarcrest\\u0060 queues from an alert\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-03-22T04:17:09.3232599Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-03-24T15:14:02.9030234Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dougbu/svc.alert.5277\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022a84ff60a-5a35-4c3f-8bb9-2e40b21f88b6\u0022,\r\n        \u0022Name\u0022: \u0022Doug Bunting\u0022,\r\n        \u0022Email\u0022: \u0022dougbu@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n          \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 48681,\r\n      \u0022Title\u0022: \u0022Fix queries used for mobile devices to match grafana alerting\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-03-22T03:21:33.2564381Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-03-24T20:56:49.9057991Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/juhoyosa/add-more-queries-onprem\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u00224954a309-db5f-67cc-af54-0f1695d4e970\u0022,\r\n        \u0022Name\u0022: \u0022Juan Sebastian Hoyos Ayala\u0022,\r\n        \u0022Email\u0022: \u0022juhoyosa@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00220994e4e4-d484-4337-a745-54d4db413c14\u0022,\r\n          \u0022Name\u0022: \u0022Ilya Skuratovsky\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 48449,\r\n      \u0022Title\u0022: \u0022[main] Update dependencies from dotnet/dnceng-shared\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-03-14T05:01:28.048116Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-05-01T17:32:06.4453134Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/darc-main-51fc2a65-8127-4cfe-a029-df85e177776f\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\u0022,\r\n        \u0022Name\u0022: \u0022ProductConstructionServiceProd\u0022,\r\n        \u0022Email\u0022: \u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n          \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u002202bcc5bb-1d50-66e4-9b9f-736c0b1329e7\u0022,\r\n          \u0022Name\u0022: \u0022Epsitha Ananth\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 48348,\r\n      \u0022Title\u0022: \u0022Fix UserDb in helixapi uses password\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-03-12T17:00:17.5802335Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-03-13T17:54:56.9619664Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/enji/sql-secrets\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u00226d5d7783-3f68-61b8-ada5-d9af8319d0c8\u0022,\r\n        \u0022Name\u0022: \u0022Enji Eid\u0022,\r\n        \u0022Email\u0022: \u0022enjieid@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00224954a309-db5f-67cc-af54-0f1695d4e970\u0022,\r\n          \u0022Name\u0022: \u0022Juan Sebastian Hoyos Ayala\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u002202bcc5bb-1d50-66e4-9b9f-736c0b1329e7\u0022,\r\n          \u0022Name\u0022: \u0022Epsitha Ananth\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 48321,\r\n      \u0022Title\u0022: \u0022[main] Update dependencies from dotnet/dnceng\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-03-12T05:01:37.5184443Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-05-01T21:30:31.4134207Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/darc-main-6bedc7ec-4d5c-4c9d-ba9e-022f69a455f9\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\u0022,\r\n        \u0022Name\u0022: \u0022ProductConstructionServiceProd\u0022,\r\n        \u0022Email\u0022: \u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n          \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 48303,\r\n      \u0022Title\u0022: \u0022Remove unused SQL settings\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-03-11T14:35:20.1263072Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-03-11T19:01:28.1256352Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/enji/sql-fix\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u00226d5d7783-3f68-61b8-ada5-d9af8319d0c8\u0022,\r\n        \u0022Name\u0022: \u0022Enji Eid\u0022,\r\n        \u0022Email\u0022: \u0022enjieid@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n          \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 48206,\r\n      \u0022Title\u0022: \u0022Remove reference to HelixSigningKV from code\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-03-07T22:39:24.7400183Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-03-12T19:54:32.1702559Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/missymessa-6728\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n        \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n        \u0022Email\u0022: \u0022mjanecke@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022a84ff60a-5a35-4c3f-8bb9-2e40b21f88b6\u0022,\r\n          \u0022Name\u0022: \u0022Doug Bunting\u0022,\r\n          \u0022Vote\u0022: 0\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022db0724ea-305e-418a-969c-779e49c58ad8\u0022,\r\n          \u0022Name\u0022: \u0022David Foster (DEVOPS)\u0022,\r\n          \u0022Vote\u0022: 0\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 48203,\r\n      \u0022Title\u0022: \u0022Fix AkaMs metrics collector\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-03-07T21:25:11.2690546Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-03-11T21:11:01.5272625Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/mistucke/nnnn-fix-akams-observer\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n        \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n        \u0022Email\u0022: \u0022mistucke@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n          \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00225981d0ba-743b-6d84-9319-ec043e802737\u0022,\r\n          \u0022Name\u0022: \u0022Farhad Alizada\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 48201,\r\n      \u0022Title\u0022: \u0022Fix telemetry client initialization in the autoscale actor to use connection...\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-03-07T17:09:49.2074374Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-03-07T21:55:17.7889819Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/riarenas/fix-telemetry\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u00229e5742ee-d918-4543-99a1-616b44d67b54\u0022,\r\n        \u0022Name\u0022: \u0022Ricardo Arenas\u0022,\r\n        \u0022Email\u0022: \u0022riarenas@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 48191,\r\n      \u0022Title\u0022: \u0022Merge Production back into main\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-03-07T13:58:29.3088628Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-03-24T16:43:04.7833581Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/production\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u00229e5742ee-d918-4543-99a1-616b44d67b54\u0022,\r\n        \u0022Name\u0022: \u0022Ricardo Arenas\u0022,\r\n        \u0022Email\u0022: \u0022riarenas@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n          \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022db0724ea-305e-418a-969c-779e49c58ad8\u0022,\r\n          \u0022Name\u0022: \u0022David Foster (DEVOPS)\u0022,\r\n          \u0022Vote\u0022: 0\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 0\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 48129,\r\n      \u0022Title\u0022: \u0022Add configurable scale factor per queue\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-03-04T23:33:03.4888587Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-03-05T22:14:43.6935959Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/riarenas/add-multiplier\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u00229e5742ee-d918-4543-99a1-616b44d67b54\u0022,\r\n        \u0022Name\u0022: \u0022Ricardo Arenas\u0022,\r\n        \u0022Email\u0022: \u0022riarenas@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 48086,\r\n      \u0022Title\u0022: \u0022Add IsExternal Property to StorageContainer table and filter\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-03-03T11:58:24.2702001Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-03-18T09:50:39.7856856Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/falizada/add-is-external\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u00225981d0ba-743b-6d84-9319-ec043e802737\u0022,\r\n        \u0022Name\u0022: \u0022Farhad Alizada\u0022,\r\n        \u0022Email\u0022: \u0022falizada@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 48009,\r\n      \u0022Title\u0022: \u0022Deleting package references for removed packages\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-02-27T22:42:01.4058998Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-02-27T23:04:50.7178264Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/missymessa-remove-unused-libs\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n        \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n        \u0022Email\u0022: \u0022mjanecke@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 47956,\r\n      \u0022Title\u0022: \u0022[main] Update dependencies from dotnet/dnceng-shared\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-02-26T05:02:09.7238823Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-03-11T22:22:49.0906142Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/darc-main-50e7ab45-a9eb-424b-bdd4-3283addcfa21\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\u0022,\r\n        \u0022Name\u0022: \u0022ProductConstructionServiceProd\u0022,\r\n        \u0022Email\u0022: \u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n          \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 47900,\r\n      \u0022Title\u0022: \u0022[main] Update dependencies from dotnet/dnceng\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-02-25T05:01:58.2047265Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-03-12T17:32:37.6182153Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/darc-main-df424632-6f4b-490e-a78c-87b7feb8101f\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\u0022,\r\n        \u0022Name\u0022: \u0022ProductConstructionServiceProd\u0022,\r\n        \u0022Email\u0022: \u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n          \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 47871,\r\n      \u0022Title\u0022: \u0022remove no needed firewall scripts\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-02-24T15:40:10.7046328Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-02-25T09:29:37.9545755Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/enji/remove-firewall\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u00226d5d7783-3f68-61b8-ada5-d9af8319d0c8\u0022,\r\n        \u0022Name\u0022: \u0022Enji Eid\u0022,\r\n        \u0022Email\u0022: \u0022enjieid@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00229e5742ee-d918-4543-99a1-616b44d67b54\u0022,\r\n          \u0022Name\u0022: \u0022Ricardo Arenas\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 47870,\r\n      \u0022Title\u0022: \u0022use service principal to deploy helix-data\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-02-24T15:38:48.0321501Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-03-05T12:52:46.3584941Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/enji/update-helixdata-deployment\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u00226d5d7783-3f68-61b8-ada5-d9af8319d0c8\u0022,\r\n        \u0022Name\u0022: \u0022Enji Eid\u0022,\r\n        \u0022Email\u0022: \u0022enjieid@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00225981d0ba-743b-6d84-9319-ec043e802737\u0022,\r\n          \u0022Name\u0022: \u0022Farhad Alizada\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 47788,\r\n      \u0022Title\u0022: \u0022Add ListOnPremMachinesNeedingHelp tool\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-02-20T06:35:50.1047213Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-02-20T18:24:44.615177Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/juhoyosa/add-onprem-tool\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u00224954a309-db5f-67cc-af54-0f1695d4e970\u0022,\r\n        \u0022Name\u0022: \u0022Juan Sebastian Hoyos Ayala\u0022,\r\n        \u0022Email\u0022: \u0022juhoyosa@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00220994e4e4-d484-4337-a745-54d4db413c14\u0022,\r\n          \u0022Name\u0022: \u0022Ilya Skuratovsky\u0022,\r\n          \u0022Vote\u0022: 0\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 47783,\r\n      \u0022Title\u0022: \u0022Remove secrets related to rollout scorer\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-02-19T19:32:43.7261151Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-02-19T21:48:30.5333557Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/missymessa-4658\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n        \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n        \u0022Email\u0022: \u0022mjanecke@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 47782,\r\n      \u0022Title\u0022: \u0022Update DB using service connection\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-02-19T16:36:15.4546495Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-03-05T20:57:41.4054644Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/enji/sql-passwords\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u00226d5d7783-3f68-61b8-ada5-d9af8319d0c8\u0022,\r\n        \u0022Name\u0022: \u0022Enji Eid\u0022,\r\n        \u0022Email\u0022: \u0022enjieid@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 47736,\r\n      \u0022Title\u0022: \u0022Pin NuGet restore task version\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-02-18T09:11:21.9732797Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-02-18T17:52:51.2782783Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/janielsen/nuget-restore-task-version\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u002269178761-8b3b-61ec-99bb-adddbae2c7d3\u0022,\r\n        \u0022Name\u0022: \u0022Jakob Botsch Nielsen\u0022,\r\n        \u0022Email\u0022: \u0022janielsen@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00226d5d7783-3f68-61b8-ada5-d9af8319d0c8\u0022,\r\n          \u0022Name\u0022: \u0022Enji Eid\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 47547,\r\n      \u0022Title\u0022: \u0022Introduce the concept of a minCapacity to the autoscale configuration\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-02-12T08:20:21.0285644Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-02-12T23:03:00.4678137Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/riarenas/add-min-scale\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u00229e5742ee-d918-4543-99a1-616b44d67b54\u0022,\r\n        \u0022Name\u0022: \u0022Ricardo Arenas\u0022,\r\n        \u0022Email\u0022: \u0022riarenas@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00220994e4e4-d484-4337-a745-54d4db413c14\u0022,\r\n          \u0022Name\u0022: \u0022Ilya Skuratovsky\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 0\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 47541,\r\n      \u0022Title\u0022: \u0022[main] Update dependencies from dotnet/dnceng-shared\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-02-12T05:01:23.3897556Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-02-21T19:17:50.115608Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/darc-main-4b422bea-8e0b-4a50-a27f-17614ba1ff19\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\u0022,\r\n        \u0022Name\u0022: \u0022ProductConstructionServiceProd\u0022,\r\n        \u0022Email\u0022: \u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 47518,\r\n      \u0022Title\u0022: \u0022Upload app package using the Service Principle\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-02-11T17:27:51.5329959Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-02-13T08:19:29.4376482Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/falizada/use-connected-to-upload-package\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u00225981d0ba-743b-6d84-9319-ec043e802737\u0022,\r\n        \u0022Name\u0022: \u0022Farhad Alizada\u0022,\r\n        \u0022Email\u0022: \u0022falizada@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00229e5742ee-d918-4543-99a1-616b44d67b54\u0022,\r\n          \u0022Name\u0022: \u0022Ricardo Arenas\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 47437,\r\n      \u0022Title\u0022: \u0022Add container info to exception\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-02-10T09:14:50.3957555Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-02-11T15:34:47.7729028Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/falizada/add-more-logs-to-exception\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u00225981d0ba-743b-6d84-9319-ec043e802737\u0022,\r\n        \u0022Name\u0022: \u0022Farhad Alizada\u0022,\r\n        \u0022Email\u0022: \u0022falizada@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00229e5742ee-d918-4543-99a1-616b44d67b54\u0022,\r\n          \u0022Name\u0022: \u0022Ricardo Arenas\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 47427,\r\n      \u0022Title\u0022: \u0022[main] Update dependencies from dotnet/dnceng\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-02-08T05:01:57.6461445Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-02-10T20:12:09.4369648Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/darc-main-734e0d1a-e13d-4b10-a16f-2face0e768d2\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\u0022,\r\n        \u0022Name\u0022: \u0022ProductConstructionServiceProd\u0022,\r\n        \u0022Email\u0022: \u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 47318,\r\n      \u0022Title\u0022: \u0022Revert \\u0022Merged PR 47204: Use the connected account for context\\u0022\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-02-04T18:52:05.2514266Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-02-04T19:25:56.5226588Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/falizada/revert-useconnected\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u00225981d0ba-743b-6d84-9319-ec043e802737\u0022,\r\n        \u0022Name\u0022: \u0022Farhad Alizada\u0022,\r\n        \u0022Email\u0022: \u0022falizada@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00229e5742ee-d918-4543-99a1-616b44d67b54\u0022,\r\n          \u0022Name\u0022: \u0022Ricardo Arenas\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 47291,\r\n      \u0022Title\u0022: \u0022Move secret to arcade\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-02-03T17:36:11.7050794Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-02-05T17:11:13.5868459Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/move-secret-to-arcade\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022ab548af8-1ef9-4928-8fd6-2014ea725a67\u0022,\r\n        \u0022Name\u0022: \u0022Matt Mitchell (.NET)\u0022,\r\n        \u0022Email\u0022: \u0022mmitche@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00229e5742ee-d918-4543-99a1-616b44d67b54\u0022,\r\n          \u0022Name\u0022: \u0022Ricardo Arenas\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 47277,\r\n      \u0022Title\u0022: \u0022Merge Production =\\u003E main\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-02-01T00:40:27.3179957Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-02-03T17:46:26.5083519Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/production\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022db0724ea-305e-418a-969c-779e49c58ad8\u0022,\r\n        \u0022Name\u0022: \u0022David Foster (DEVOPS)\u0022,\r\n        \u0022Email\u0022: \u0022davfost@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022a84ff60a-5a35-4c3f-8bb9-2e40b21f88b6\u0022,\r\n          \u0022Name\u0022: \u0022Doug Bunting\u0022,\r\n          \u0022Vote\u0022: 0\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00220994e4e4-d484-4337-a745-54d4db413c14\u0022,\r\n          \u0022Name\u0022: \u0022Ilya Skuratovsky\u0022,\r\n          \u0022Vote\u0022: 0\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00229e5742ee-d918-4543-99a1-616b44d67b54\u0022,\r\n          \u0022Name\u0022: \u0022Ricardo Arenas\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022db0724ea-305e-418a-969c-779e49c58ad8\u0022,\r\n          \u0022Name\u0022: \u0022David Foster (DEVOPS)\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 0\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 47231,\r\n      \u0022Title\u0022: \u0022[main] Update dependencies from dotnet/dnceng-shared\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-01-31T05:01:54.0121286Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-02-07T18:36:22.9190846Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/darc-main-8ca33b4a-ad99-42f6-a3a5-89746addef08\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\u0022,\r\n        \u0022Name\u0022: \u0022ProductConstructionServiceProd\u0022,\r\n        \u0022Email\u0022: \u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00224954a309-db5f-67cc-af54-0f1695d4e970\u0022,\r\n          \u0022Name\u0022: \u0022Juan Sebastian Hoyos Ayala\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00229e5742ee-d918-4543-99a1-616b44d67b54\u0022,\r\n          \u0022Name\u0022: \u0022Ricardo Arenas\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 47215,\r\n      \u0022Title\u0022: \u0022Update autoscale alerts runbook\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-01-30T17:18:38.8911678Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-01-30T19:34:56.8538863Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/meghnave/update_autoscale_runbook\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u002211d4085b-6535-6a6c-a5ef-c87bedeca35e\u0022,\r\n        \u0022Name\u0022: \u0022Meghna Verma\u0022,\r\n        \u0022Email\u0022: \u0022meghnaverma@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00229e5742ee-d918-4543-99a1-616b44d67b54\u0022,\r\n          \u0022Name\u0022: \u0022Ricardo Arenas\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 47204,\r\n      \u0022Title\u0022: \u0022Use the connected account for context\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-01-30T12:14:23.0722448Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-02-03T13:56:08.3562613Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/falizada/upload-apppackage-via-mi\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u00225981d0ba-743b-6d84-9319-ec043e802737\u0022,\r\n        \u0022Name\u0022: \u0022Farhad Alizada\u0022,\r\n        \u0022Email\u0022: \u0022falizada@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00220994e4e4-d484-4337-a745-54d4db413c14\u0022,\r\n          \u0022Name\u0022: \u0022Ilya Skuratovsky\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u002269178761-8b3b-61ec-99bb-adddbae2c7d3\u0022,\r\n          \u0022Name\u0022: \u0022Jakob Botsch Nielsen\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 47184,\r\n      \u0022Title\u0022: \u0022Deploy production VMSS via templates\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-01-29T18:58:55.7458136Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-01-31T09:59:28.3895124Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/janielsen/vmss-prod-deployment\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u002269178761-8b3b-61ec-99bb-adddbae2c7d3\u0022,\r\n        \u0022Name\u0022: \u0022Jakob Botsch Nielsen\u0022,\r\n        \u0022Email\u0022: \u0022janielsen@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00229e5742ee-d918-4543-99a1-616b44d67b54\u0022,\r\n          \u0022Name\u0022: \u0022Ricardo Arenas\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00225981d0ba-743b-6d84-9319-ec043e802737\u0022,\r\n          \u0022Name\u0022: \u0022Farhad Alizada\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 47092,\r\n      \u0022Title\u0022: \u0022Add secrets to VMSS template\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-01-27T16:22:53.9452003Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-01-29T09:02:34.3534862Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/janielsen/vmss-add-secrets\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u002269178761-8b3b-61ec-99bb-adddbae2c7d3\u0022,\r\n        \u0022Name\u0022: \u0022Jakob Botsch Nielsen\u0022,\r\n        \u0022Email\u0022: \u0022janielsen@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00224954a309-db5f-67cc-af54-0f1695d4e970\u0022,\r\n          \u0022Name\u0022: \u0022Juan Sebastian Hoyos Ayala\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00225981d0ba-743b-6d84-9319-ec043e802737\u0022,\r\n          \u0022Name\u0022: \u0022Farhad Alizada\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 47017,\r\n      \u0022Title\u0022: \u0022Remove IaaSDiagnostics extension from VMSS\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-01-24T11:50:52.9560989Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-02-07T09:59:26.2541625Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/janielsen/vmss-no-diagnostics\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u002269178761-8b3b-61ec-99bb-adddbae2c7d3\u0022,\r\n        \u0022Name\u0022: \u0022Jakob Botsch Nielsen\u0022,\r\n        \u0022Email\u0022: \u0022janielsen@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00224954a309-db5f-67cc-af54-0f1695d4e970\u0022,\r\n          \u0022Name\u0022: \u0022Juan Sebastian Hoyos Ayala\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n          \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00225981d0ba-743b-6d84-9319-ec043e802737\u0022,\r\n          \u0022Name\u0022: \u0022Farhad Alizada\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 47016,\r\n      \u0022Title\u0022: \u0022Skip production deployment of VMSS from templates\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-01-24T11:24:37.8719098Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-01-24T17:01:26.3473903Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/janielsen/vmss-skip-prod-deployment\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u002269178761-8b3b-61ec-99bb-adddbae2c7d3\u0022,\r\n        \u0022Name\u0022: \u0022Jakob Botsch Nielsen\u0022,\r\n        \u0022Email\u0022: \u0022janielsen@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00229e5742ee-d918-4543-99a1-616b44d67b54\u0022,\r\n          \u0022Name\u0022: \u0022Ricardo Arenas\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00225981d0ba-743b-6d84-9319-ec043e802737\u0022,\r\n          \u0022Name\u0022: \u0022Farhad Alizada\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 46990,\r\n      \u0022Title\u0022: \u0022[Service Fabric] Update auth type of downloading file in VMSS during the provision\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-01-23T12:26:26.1730524Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-02-06T21:46:17.9297365Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/enji/Use-MI-with-CustomScriptextension\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u00226d5d7783-3f68-61b8-ada5-d9af8319d0c8\u0022,\r\n        \u0022Name\u0022: \u0022Enji Eid\u0022,\r\n        \u0022Email\u0022: \u0022enjieid@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n          \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u002269178761-8b3b-61ec-99bb-adddbae2c7d3\u0022,\r\n          \u0022Name\u0022: \u0022Jakob Botsch Nielsen\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00225981d0ba-743b-6d84-9319-ec043e802737\u0022,\r\n          \u0022Name\u0022: \u0022Farhad Alizada\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 46955,\r\n      \u0022Title\u0022: \u0022Add a bicep template for VMSS deployment\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-01-22T11:11:51.0116823Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-01-23T09:50:12.9339469Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/janielsen/vmss-bicep-template\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u002269178761-8b3b-61ec-99bb-adddbae2c7d3\u0022,\r\n        \u0022Name\u0022: \u0022Jakob Botsch Nielsen\u0022,\r\n        \u0022Email\u0022: \u0022janielsen@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022da8e23bb-3123-4efe-9074-87b88acf60b7\u0022,\r\n          \u0022Name\u0022: \u0022Christopher Costa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00225981d0ba-743b-6d84-9319-ec043e802737\u0022,\r\n          \u0022Name\u0022: \u0022Farhad Alizada\u0022,\r\n          \u0022Vote\u0022: 0\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 46779,\r\n      \u0022Title\u0022: \u0022Update Diagnostics fabricSettings to use MI \u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-01-16T08:49:56.3240542Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-01-17T09:53:15.1059845Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/falizada/update-sf-diag-settings\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u00225981d0ba-743b-6d84-9319-ec043e802737\u0022,\r\n        \u0022Name\u0022: \u0022Farhad Alizada\u0022,\r\n        \u0022Email\u0022: \u0022falizada@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 46728,\r\n      \u0022Title\u0022: \u0022[main] Update dependencies from dotnet/dnceng\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-01-15T05:02:16.7546254Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-02-07T18:05:44.1185076Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/darc-main-55f48001-2cea-4232-b4e8-c74a543fc14c\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\u0022,\r\n        \u0022Name\u0022: \u0022ProductConstructionServiceProd\u0022,\r\n        \u0022Email\u0022: \u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 46724,\r\n      \u0022Title\u0022: \u0022Revert 1ES PT Release Tasks bits\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-01-14T21:47:27.8375603Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-01-14T23:38:51.1316292Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/mistucke/4311-revert-release-tasks\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n        \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n        \u0022Email\u0022: \u0022mistucke@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00224954a309-db5f-67cc-af54-0f1695d4e970\u0022,\r\n          \u0022Name\u0022: \u0022Juan Sebastian Hoyos Ayala\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n          \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 46597,\r\n      \u0022Title\u0022: \u0022Fixup some additional wayward release tasks\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-01-09T00:07:27.6442168Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-01-09T00:40:20.2152017Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/mistucke/4311-part-2\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n        \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n        \u0022Email\u0022: \u0022mistucke@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022ab548af8-1ef9-4928-8fd6-2014ea725a67\u0022,\r\n          \u0022Name\u0022: \u0022Matt Mitchell (.NET)\u0022,\r\n          \u0022Vote\u0022: 0\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n          \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 46560,\r\n      \u0022Title\u0022: \u0022[main] Update dependencies from dotnet/dnceng\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-01-08T05:01:31.4054157Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-01-09T00:49:44.5612699Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/darc-main-8b354566-3a5b-4686-a409-7f4ccebe8607\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\u0022,\r\n        \u0022Name\u0022: \u0022ProductConstructionServiceProd\u0022,\r\n        \u0022Email\u0022: \u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 46555,\r\n      \u0022Title\u0022: \u0022Update helix-admin list to account for team member changes\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-01-07T22:06:42.9653773Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-01-08T19:07:03.3624483Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/meghnave/update-helix-admin-list\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u002211d4085b-6535-6a6c-a5ef-c87bedeca35e\u0022,\r\n        \u0022Name\u0022: \u0022Meghna Verma\u0022,\r\n        \u0022Email\u0022: \u0022meghnaverma@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022a84ff60a-5a35-4c3f-8bb9-2e40b21f88b6\u0022,\r\n          \u0022Name\u0022: \u0022Doug Bunting\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n          \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 46488,\r\n      \u0022Title\u0022: \u0022[main] Update dependencies from dotnet/dnceng\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-01-04T05:01:35.097041Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-01-07T19:35:37.4754765Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/darc-main-76f7b805-c38c-4cc7-b5ba-76672da4638d\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\u0022,\r\n        \u0022Name\u0022: \u0022ProductConstructionServiceProd\u0022,\r\n        \u0022Email\u0022: \u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 46487,\r\n      \u0022Title\u0022: \u0022[main] Update dependencies from dotnet/dnceng-shared\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-01-04T05:01:33.3783Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-01-07T22:56:11.4928266Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/darc-main-0807d97e-2619-4051-9db0-32344f2c2259\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\u0022,\r\n        \u0022Name\u0022: \u0022ProductConstructionServiceProd\u0022,\r\n        \u0022Email\u0022: \u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1f55bb3-0f83-65fa-8753-6f328b94345e\u0022,\r\n          \u0022Name\u0022: \u0022Haruna Ogweda\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022db0724ea-305e-418a-969c-779e49c58ad8\u0022,\r\n          \u0022Name\u0022: \u0022David Foster (DEVOPS)\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 46460,\r\n      \u0022Title\u0022: \u0022[main] Update dependencies from dotnet/dnceng-shared\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222025-01-03T05:01:32.6142276Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-01-03T21:46:53.841062Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/darc-main-8987be80-f88f-4fad-a529-9a356673d812\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022c81111e3-e146-69f1-b0a6-dd3ca4dde3a0\u0022,\r\n        \u0022Name\u0022: \u0022ProductConstructionServiceProd\u0022,\r\n        \u0022Email\u0022: \u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\e4733d54-0ffa-4e0a-9e7e-1935b7dc8a54\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 46410,\r\n      \u0022Title\u0022: \u0022Use release jobs in the deployment stage\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222024-12-31T18:39:56.7021672Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-01-08T23:33:06.4321581Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/use-release-job\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022ab548af8-1ef9-4928-8fd6-2014ea725a67\u0022,\r\n        \u0022Name\u0022: \u0022Matt Mitchell (.NET)\u0022,\r\n        \u0022Email\u0022: \u0022mmitche@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 46041,\r\n      \u0022Title\u0022: \u0022[main] Update dependencies from dotnet/dnceng\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222024-12-14T13:30:11.9752581Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222024-12-30T22:45:43.6574181Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/darc-main-ac6fc9f7-a6ab-4a93-98be-229a4b20bf3f\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022e247ef8c-b6cf-6ca6-9c94-5a3a9c583c07\u0022,\r\n        \u0022Name\u0022: \u0022maestro-prod-Primary\u0022,\r\n        \u0022Email\u0022: \u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\610d53f3-8c41-42a0-9941-cb44eecfa176\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 45847,\r\n      \u0022Title\u0022: \u0022Rolling back the Azure.Identity nuget to version 1.12.1\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222024-12-10T21:13:08.3492333Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222024-12-10T21:40:15.1687517Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/davfost/20241210_BuildFailure\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022db0724ea-305e-418a-969c-779e49c58ad8\u0022,\r\n        \u0022Name\u0022: \u0022David Foster (DEVOPS)\u0022,\r\n        \u0022Email\u0022: \u0022davfost@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00220994e4e4-d484-4337-a745-54d4db413c14\u0022,\r\n          \u0022Name\u0022: \u0022Ilya Skuratovsky\u0022,\r\n          \u0022Vote\u0022: 0\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00229e5742ee-d918-4543-99a1-616b44d67b54\u0022,\r\n          \u0022Name\u0022: \u0022Ricardo Arenas\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1f55bb3-0f83-65fa-8753-6f328b94345e\u0022,\r\n          \u0022Name\u0022: \u0022Haruna Ogweda\u0022,\r\n          \u0022Vote\u0022: 0\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022db0724ea-305e-418a-969c-779e49c58ad8\u0022,\r\n          \u0022Name\u0022: \u0022David Foster (DEVOPS)\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 0\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 45732,\r\n      \u0022Title\u0022: \u0022[main] Update dependencies from dotnet/dnceng-shared\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222024-12-06T13:32:25.7109131Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222024-12-31T19:38:51.2624596Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/darc-main-721fdaea-5294-48f8-9562-9d185cdeb680\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022e247ef8c-b6cf-6ca6-9c94-5a3a9c583c07\u0022,\r\n        \u0022Name\u0022: \u0022maestro-prod-Primary\u0022,\r\n        \u0022Email\u0022: \u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\610d53f3-8c41-42a0-9941-cb44eecfa176\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022a84ff60a-5a35-4c3f-8bb9-2e40b21f88b6\u0022,\r\n          \u0022Name\u0022: \u0022Doug Bunting\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 45631,\r\n      \u0022Title\u0022: \u0022Look for AzDO issues in PRs as well as GitHub issues\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222024-12-03T19:01:18.0068558Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222024-12-04T16:17:50.4413523Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/missymessa-7191\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n        \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n        \u0022Email\u0022: \u0022mjanecke@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022a84ff60a-5a35-4c3f-8bb9-2e40b21f88b6\u0022,\r\n          \u0022Name\u0022: \u0022Doug Bunting\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 45421,\r\n      \u0022Title\u0022: \u0022enable PoliCheck and TSA in dotnet-helix-service-ci pipeline\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222024-11-26T23:56:40.6679543Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222024-12-04T18:50:40.3601945Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/haruna/tsa-compliance\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022b1f55bb3-0f83-65fa-8753-6f328b94345e\u0022,\r\n        \u0022Name\u0022: \u0022Haruna Ogweda\u0022,\r\n        \u0022Email\u0022: \u0022harunaogweda@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00229e5742ee-d918-4543-99a1-616b44d67b54\u0022,\r\n          \u0022Name\u0022: \u0022Ricardo Arenas\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 45191,\r\n      \u0022Title\u0022: \u0022[SECURITY] Bump System.Text.Json from 8.0.4 to 8.0.5 in /src\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222024-11-21T05:08:39.885722Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222024-11-22T18:55:10.3892846Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dependabot/nuget/src/System.Text.Json-8.0.5-71988\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u002200000072-0000-8888-8000-000000000000\u0022,\r\n        \u0022Name\u0022: \u0022Dependabot\u0022,\r\n        \u0022Email\u0022: \u002200000072-0000-8888-8000-000000000000@2c895908-04e0-4952-89fd-54b0046d6288\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00229e5742ee-d918-4543-99a1-616b44d67b54\u0022,\r\n          \u0022Name\u0022: \u0022Ricardo Arenas\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 45159,\r\n      \u0022Title\u0022: \u0022[A11y] Use underline text style instead of \\u003Cu\\u003E tags\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222024-11-20T16:03:12.274834Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222024-11-20T17:07:25.1680961Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/riarenas/fix-underline-styling\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u00229e5742ee-d918-4543-99a1-616b44d67b54\u0022,\r\n        \u0022Name\u0022: \u0022Ricardo Arenas\u0022,\r\n        \u0022Email\u0022: \u0022riarenas@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00220994e4e4-d484-4337-a745-54d4db413c14\u0022,\r\n          \u0022Name\u0022: \u0022Ilya Skuratovsky\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 44959,\r\n      \u0022Title\u0022: \u0022Post-deployment merge of the production branch back to main branch\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222024-11-13T21:46:24.9229245Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222024-11-13T22:11:13.3140566Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/production\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022db0724ea-305e-418a-969c-779e49c58ad8\u0022,\r\n        \u0022Name\u0022: \u0022David Foster (DEVOPS)\u0022,\r\n        \u0022Email\u0022: \u0022davfost@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00229e5742ee-d918-4543-99a1-616b44d67b54\u0022,\r\n          \u0022Name\u0022: \u0022Ricardo Arenas\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022db0724ea-305e-418a-969c-779e49c58ad8\u0022,\r\n          \u0022Name\u0022: \u0022David Foster (DEVOPS)\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 44946,\r\n      \u0022Title\u0022: \u0022Move the definition SF cluster from Azure Portal to bicep template\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222024-11-13T14:13:36.7115174Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222025-01-03T10:06:46.1705853Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/falizada/service-fabric-deployment\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u00225981d0ba-743b-6d84-9319-ec043e802737\u0022,\r\n        \u0022Name\u0022: \u0022Farhad Alizada\u0022,\r\n        \u0022Email\u0022: \u0022falizada@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022a84ff60a-5a35-4c3f-8bb9-2e40b21f88b6\u0022,\r\n          \u0022Name\u0022: \u0022Doug Bunting\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00220994e4e4-d484-4337-a745-54d4db413c14\u0022,\r\n          \u0022Name\u0022: \u0022Ilya Skuratovsky\u0022,\r\n          \u0022Vote\u0022: 0\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 44833,\r\n      \u0022Title\u0022: \u0022Fix passing rsas and wsas to JobCreationRequest\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222024-11-08T15:37:31.5536539Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222024-11-09T09:14:54.4437741Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/srozsival/fix-job-creation-request-wsas\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u002214b37c7b-4c51-6bd6-b73e-63b8a6db0616\u0022,\r\n        \u0022Name\u0022: \u0022Simon Rozsival\u0022,\r\n        \u0022Email\u0022: \u0022srozsival@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n          \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00225981d0ba-743b-6d84-9319-ec043e802737\u0022,\r\n          \u0022Name\u0022: \u0022Farhad Alizada\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 44832,\r\n      \u0022Title\u0022: \u0022Remove the creation of resource group functionality in Storage account creation\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222024-11-08T14:20:00.4426464Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222024-11-11T12:23:10.8107106Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/falizada/remove-resource-group-creation-deprecate\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u00225981d0ba-743b-6d84-9319-ec043e802737\u0022,\r\n        \u0022Name\u0022: \u0022Farhad Alizada\u0022,\r\n        \u0022Email\u0022: \u0022falizada@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022b1973a2f-03eb-6fce-b5a3-63ca6ed23f8f\u0022,\r\n          \u0022Name\u0022: \u0022Missy Messa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 44604,\r\n      \u0022Title\u0022: \u0022Disable shared key access for newly created storage accounts in tests\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222024-11-04T12:00:51.9065535Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222024-11-23T12:02:19.1816901Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/dev/srozsival/disable-shared-key-access-to-storage-accounts-created-by-azure-resource-helper\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u002214b37c7b-4c51-6bd6-b73e-63b8a6db0616\u0022,\r\n        \u0022Name\u0022: \u0022Simon Rozsival\u0022,\r\n        \u0022Email\u0022: \u0022srozsival@microsoft.com\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022da8e23bb-3123-4efe-9074-87b88acf60b7\u0022,\r\n          \u0022Name\u0022: \u0022Christopher Costa\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u00225981d0ba-743b-6d84-9319-ec043e802737\u0022,\r\n          \u0022Name\u0022: \u0022Farhad Alizada\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \u0022PullRequestId\u0022: 44473,\r\n      \u0022Title\u0022: \u0022[main] Update dependencies from dotnet/dnceng\u0022,\r\n      \u0022Status\u0022: 3,\r\n      \u0022CreationDate\u0022: \u00222024-10-29T12:10:05.5418871Z\u0022,\r\n      \u0022ClosedDate\u0022: \u00222024-12-14T01:35:52.9836523Z\u0022,\r\n      \u0022SourceRefName\u0022: \u0022refs/heads/darc-main-7e587618-7db1-422f-9f2f-c9fdce65b50b\u0022,\r\n      \u0022TargetRefName\u0022: \u0022refs/heads/main\u0022,\r\n      \u0022Creator\u0022: {\r\n        \u0022Id\u0022: \u0022e247ef8c-b6cf-6ca6-9c94-5a3a9c583c07\u0022,\r\n        \u0022Name\u0022: \u0022maestro-prod-Primary\u0022,\r\n        \u0022Email\u0022: \u002272f988bf-86f1-41af-91ab-2d7cd011db47\\\\610d53f3-8c41-42a0-9941-cb44eecfa176\u0022\r\n      },\r\n      \u0022Reviewers\u0022: [\r\n        {\r\n          \u0022Id\u0022: \u00225d578427-4dda-426c-8212-0760e978f0ab\u0022,\r\n          \u0022Name\u0022: \u0022[TEAM FOUNDATION]\\\\MaWilkie\\u0027s Direct Reports\u0022,\r\n          \u0022Vote\u0022: 10\r\n        },\r\n        {\r\n          \u0022Id\u0022: \u0022bd413ef1-76d5-6333-81e6-82cd5d6c365d\u0022,\r\n          \u0022Name\u0022: \u0022Michael Stuckey\u0022,\r\n          \u0022Vote\u0022: 10\r\n        }\r\n      ]\r\n    }\r\n  ]\r\n}"
        }
      ],
      "count": 1
    }
  }
}
```
