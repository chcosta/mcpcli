# Step 5: Find Changes Merged to Main After Last Deployment

**Plan**: 20250709-061905-6a8ce1c3
**Status**: Failed
**Started**: 2025-07-09T06:20:14Z
**Completed**: 2025-07-09T06:20:18Z
**Duration**: 4.80 seconds

## Goal
List all pull requests merged to the main branch after the last production deployment identified in Step 4.

## Prompt
Get pull requests for the main branch in the 'dotnet-helix-service' repository filtered by closed date after the last production deployment date, ordered by creation date descending.

## Execution Details

## Error
This model's maximum context length is 128000 tokens. However, your messages resulted in 202549 tokens. Please reduce the length of the messages.
Status: 400 (Bad Request)
ErrorCode: context_length_exceeded

Content:
{
  "error": {
    "message": "This model's maximum context length is 128000 tokens. However, your messages resulted in 202549 tokens. Please reduce the length of the messages.",
    "type": "invalid_request_error",
    "param": "messages",
    "code": "context_length_exceeded"
  }
}

Headers:
apim-request-id: REDACTED
Strict-Transport-Security: REDACTED
x-ratelimit-limit-requests: REDACTED
X-Content-Type-Options: REDACTED
x-ms-region: REDACTED
x-ratelimit-remaining-tokens: REDACTED
x-ms-rai-invoked: REDACTED
X-Request-ID: REDACTED
x-ratelimit-remaining-requests: REDACTED
x-ms-client-request-id: b305b618-1483-4b3c-b581-e4b880542037
x-ms-deployment-name: REDACTED
x-ratelimit-limit-tokens: REDACTED
Date: Wed, 09 Jul 2025 06:20:20 GMT
Content-Length: 284
Content-Type: application/json

