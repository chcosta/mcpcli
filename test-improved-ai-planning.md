---
name: "Test Improved AI Planning"
description: "Test configuration for improved AI planning with better tool awareness"
azure_ai:
  endpoint: "https://your-resource.openai.azure.com/"
  api_key: "your-api-key"
  deployment_name: "your-deployment"
  model_name: "gpt-4"
preview_features: true
servers:
  - name: "azure-devops"
    type: "git"
    enabled: true
    local_path: "mcp-servers/dnceng-ai-experimental"
    tool_defaults:
      initialize_azure_dev_ops_client:
        organizationUrl: "https://dev.azure.com/dnceng"
      get_projects:
        organizationName: "dnceng"
      get_repositories:
        organizationName: "dnceng"
        projectName: "internal"
      get_pull_requests:
        organizationName: "dnceng"
        projectName: "internal"
        repositoryName: "dotnet"
        targetBranch: "main"
        status: "completed"
        maxCount: 10
      get_pull_request_description:
        organizationName: "dnceng"
        projectName: "internal"
      get_pull_requests_by_creation_date:
        organizationName: "dnceng"
        projectName: "internal"
        repositoryName: "dotnet"
        maxCount: 10
      get_pull_requests_by_closed_date:
        organizationName: "dnceng"
        projectName: "internal"
        repositoryName: "dotnet"
        maxCount: 10
      get_work_items:
        projectName: "internal"
        wiqlQuery: "SELECT [System.Id] FROM WorkItems WHERE [System.TeamProject] = 'internal' AND [System.State] = 'Active'"
--- 