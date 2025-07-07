# Multi-Server MCP Implementation Plan

## 🎯 **Overview**

This document outlines the implementation plan for adding support for multiple MCP servers to the MCP CLI tool. The feature will support both **git-based servers** (local repositories) and **HTTP-based servers** (remote endpoints). **Note: This is a breaking change that requires users to migrate from the legacy single-server format to the new multi-server format.**

## 🏗️ **Architecture Design**

### **Configuration Model**

```yaml
# MCP Servers Configuration
servers:
  - name: "azure-devops"
    type: "git"
    url: "https://dev.azure.com/org/project/_git/repo"
    enabled: true
    auto_start: true
    port: 3000
    tool_defaults:
      initialize_client: { organizationUrl: "dnceng" }
      
  - name: "weather-api"
    type: "http"
    url: "https://weather-api.example.com"
    enabled: true
    headers:
      Authorization: "Bearer ${API_TOKEN}"
    
  - name: "dev-server"
    type: "git"
    url: "https://github.com/org/dev-server"
    enabled: false
    auto_start: false
    port: 3001
    description: "Development server - disabled by default"
```

### **Core Components**

1. **Configuration Models**
   - `MultiMcpServerConfig` - Individual server configuration with enable/disable support
   - `MarkdownConfig` - Simplified with servers list only (no legacy support)
   - `RunningServerInfo` - Runtime server state
   - `ServerToolMapping` - Tool-to-server routing
   - `ServerStatus` - Server status information including enabled/disabled state

2. **Service Layer**
   - `IMultiMcpServerService` - Multi-server management interface
   - `MultiMcpServerService` - Implementation for server lifecycle
   - Extended `MarkdownConfigService` - Parse multi-server configs

3. **Tool Resolution**
   - `ServerToolMapping` - Maps tools to servers
   - Conflict resolution for duplicate tool names
   - Fallback behavior when servers are unavailable

## 📋 **Implementation Phases**

### **Phase 1: Core Infrastructure** ✅

**Status**: COMPLETED

- [x] Create `MultiMcpServerConfig` model
- [x] Extend `MarkdownConfig` with servers list
- [x] Add backward compatibility with `IsLegacyMode` property
- [x] Update `MarkdownConfigService` to parse servers section
- [x] Create `IMultiMcpServerService` interface
- [x] Update configuration validation for both modes
- [x] Generate example configurations

**Deliverables**:
- Configuration models support new multi-server format only
- YAML parsing handles server arrays with nested properties
- Server enable/disable functionality built into configuration
- Validation ensures required fields for each server type
- Example configurations demonstrate different server types and enabled/disabled states

### **Phase 2: Server Management Service** ✅

**Status**: COMPLETED

**Tasks**:
- [x] Implement `MultiMcpServerService` class
- [x] Add git server management (clone, start, stop)
- [x] Add HTTP server connection management
- [x] Implement server health checking
- [x] Add port management for multiple local servers
- [x] Handle server startup conflicts and failures
- [x] Implement server enable/disable functionality
- [x] Add server status tracking and reporting

**Key Features**:
- **Git Servers**: Clone repositories, start processes, manage lifecycle
- **HTTP Servers**: Establish connections, handle authentication
- **Health Monitoring**: Check server availability and response times
- **Error Handling**: Graceful degradation when servers fail
- **Enable/Disable**: Dynamic server activation/deactivation without configuration changes
- **Status Tracking**: Real-time server status monitoring

### **Phase 3: Tool Discovery & Routing** ✅

**Status**: COMPLETED

**Tasks**:
- [x] Implement tool discovery across all servers
- [x] Create `ServerToolMapping` with conflict resolution
- [x] Add tool routing logic to direct calls to correct servers
- [x] Implement fallback behavior for unavailable servers
- [x] Add tool namespacing for conflict resolution

**Key Features**:
- **Tool Discovery**: Enumerate available tools from all servers
- **Conflict Resolution**: Handle duplicate tool names across servers
- **Smart Routing**: Automatically route tool calls to appropriate servers
- **Fallback Support**: Continue execution when some servers are unavailable

### **Phase 4: Integration with Existing Commands** 🔄

**Status**: IN PROGRESS

**Tasks**:
- [x] Update `RunCommand` to support multi-server mode
- [x] Extend `AiPlanningService` with multi-server awareness
- [x] Update tool defaults to support per-server configuration
- [x] Add execution summary tracking for multiple servers
- [x] Implement server-specific error reporting
- [ ] Add server management commands (`mcpcli server list`, `mcpcli server enable`, `mcpcli server disable`)
- [ ] Enhance error messages with server context
- [ ] Add server performance tracking in execution summary

**Key Features**:
- **Seamless Integration**: Existing commands work with multiple servers
- **AI Planning**: AI understands which tools come from which servers
- **Enhanced Logging**: Track tool executions across servers
- **Error Context**: Clear error messages indicating which server failed

### **Phase 5: Advanced Features**

**Status**: PENDING

**Tasks**:
- [ ] Add server tagging and filtering
- [ ] Implement parallel tool execution across servers
- [ ] Add server-specific environment variables
- [ ] Create server management commands (`mcpcli server list`, `mcpcli server enable`, `mcpcli server disable`)
- [ ] Add server performance monitoring and metrics
- [ ] Implement server enable/disable commands

**Key Features**:
- **Server Tags**: Filter and group servers by purpose
- **Parallel Execution**: Run tools on multiple servers simultaneously
- **Management Commands**: Control individual servers
- **Performance Monitoring**: Track server response times and health

## 🔄 **Migration Strategy**

### **Breaking Changes**

This implementation introduces breaking changes that require users to migrate their configuration:

1. **Legacy Format Removal**: The old `repository_url` and `mcp_server` configuration is no longer supported
2. **New Format Required**: All configurations must use the new `servers` array format
3. **Configuration Validation**: Existing configurations will fail validation until migrated

### **Migration Path**

Users must migrate their configurations to the new format:

**Before (Legacy Format):**
```yaml
repository_url: "https://github.com/org/repo"
mcp_server:
  port: 3000
  auto_start: true
  environment:
    NODE_ENV: "production"
```

**After (New Format):**
```yaml
servers:
  - name: "primary"
    type: "git"
    url: "https://github.com/org/repo"
    enabled: true
    auto_start: true
    port: 3000
    environment:
      NODE_ENV: "production"
```

### **Migration Steps**

1. **Identify Legacy Configs**: Find all configurations using the old format
2. **Convert to New Format**: Transform each legacy config to the new servers array format
3. **Add Server Names**: Assign unique names to each server
4. **Set Enable/Disable**: Configure which servers should be enabled by default
5. **Test Configuration**: Validate the new configuration works as expected
6. **Update Scripts**: Update any automation that depends on the old configuration format

### **Migration Tools**

Recommended migration tools to be developed:

- **Configuration Validator**: Tool to check if configurations use legacy format
- **Migration Script**: Automated conversion from legacy to new format
- **Configuration Generator**: Interactive tool to help create new server configurations

## 🧪 **Testing Strategy**

### **Unit Tests**

- [ ] Configuration parsing tests for new format
- [ ] Server lifecycle management tests
- [ ] Tool discovery and routing tests
- [ ] Error handling and fallback tests
- [ ] Server enable/disable functionality tests
- [ ] Migration validation tests

### **Integration Tests**

- [ ] Multi-server startup and shutdown
- [ ] Tool execution across different server types
- [ ] AI planning with multiple servers
- [ ] Configuration validation end-to-end
- [ ] Performance under load

### **Manual Testing Scenarios**

1. **Configuration Formats**
   - New multi-server configuration
   - Server enable/disable scenarios
   - Invalid configurations (should fail gracefully)
   - Migration from legacy configurations

2. **Server Types**
   - Git server clone, start, and tool execution
   - HTTP server connection and tool execution
   - Mixed git and HTTP servers
   - Server startup failures and recovery

3. **Tool Execution**
   - Simple tool calls with single server
   - Complex AI planning with multiple servers
   - Tool conflicts and resolution
   - Server unavailability handling

4. **Error Scenarios**
   - Server startup failures
   - Network connectivity issues
   - Invalid authentication
   - Tool execution failures

## 📚 **Documentation Plan**

### **User Documentation**

- [ ] Update README with multi-server examples
- [ ] Create migration guide for existing users (breaking changes)
- [ ] Document server enable/disable functionality
- [ ] Document configuration options and validation
- [ ] Add troubleshooting guide for common issues

### **Developer Documentation**

- [ ] Service architecture documentation
- [ ] API documentation for `IMultiMcpServerService`
- [ ] Extension points for custom server types
- [ ] Performance considerations and best practices

### **Example Configurations**

- [ ] Enterprise setup with multiple internal servers
- [ ] Development setup with local and remote servers
- [ ] CI/CD pipeline integration examples
- [ ] Security best practices for HTTP servers

## 🔐 **Security Considerations**

### **Authentication & Authorization**

- **HTTP Servers**: Support for Bearer tokens, API keys, basic auth
- **Git Servers**: SSH keys, personal access tokens
- **Environment Variables**: Secure secret management
- **Server Isolation**: Prevent servers from accessing each other

### **Network Security**

- **HTTPS Enforcement**: Require HTTPS for HTTP servers
- **Certificate Validation**: Verify SSL certificates
- **Network Timeouts**: Prevent hanging connections
- **Rate Limiting**: Respect server rate limits

### **Configuration Security**

- **Secret Detection**: Prevent secrets in configuration files
- **Environment Variables**: Secure environment variable handling
- **Validation**: Strict input validation and sanitization
- **Audit Logging**: Track server connections and tool executions

## 🚀 **Deployment Strategy**

### **Feature Flags**

- Use preview features flag for initial rollout
- Gradual enabling for different user groups
- Rollback capability if issues are discovered

### **Monitoring & Observability**

- Server health monitoring
- Tool execution metrics
- Error rates and patterns
- Performance benchmarks

### **Support & Maintenance**

- Clear error messages and troubleshooting guides
- Support for both legacy and new configurations
- Regular health checks and maintenance procedures
- Documentation and training materials

## 📈 **Success Metrics**

### **Functionality Metrics**

- ✅ Support for both git and HTTP server types
- ✅ Server enable/disable functionality
- ✅ Seamless tool routing across multiple servers
- ✅ Graceful error handling and fallback behavior
- ✅ Clean migration path from legacy configurations

### **Performance Metrics**

- Server startup time < 10 seconds
- Tool execution latency < 2 seconds
- Memory usage scales linearly with server count
- CPU usage remains reasonable under load

### **User Experience Metrics**

- Clear migration path from legacy to new format
- Easy server enable/disable functionality
- Clear error messages and troubleshooting
- Intuitive configuration format
- Comprehensive documentation and examples

## 📅 **Timeline**

| Phase | Duration | Key Deliverables |
|-------|----------|------------------|
| Phase 1 | ✅ Complete | Configuration models, parsing, validation |
| Phase 2 | 1-2 weeks | Server management service implementation |
| Phase 3 | 1-2 weeks | Tool discovery and routing |
| Phase 4 | 1-2 weeks | Integration with existing commands |
| Phase 5 | 2-3 weeks | Advanced features and polish |

**Total Estimated Duration**: 5-9 weeks

## 🎉 **Next Steps**

1. **Review and Approval**: Get stakeholder approval for the implementation plan and breaking changes
2. **Migration Communication**: Notify users about the breaking changes and migration requirements
3. **Phase 2 Kickoff**: Begin implementing the `MultiMcpServerService` with enable/disable functionality
4. **Testing Setup**: Establish testing environments for both server types
5. **Documentation**: Start writing user-facing documentation including migration guides
6. **Migration Tools**: Develop tools to help users migrate from legacy configurations

---

*This implementation plan provides a comprehensive roadmap for adding multi-server support to the MCP CLI tool with server enable/disable functionality. **Note: This includes breaking changes that require users to migrate their existing configurations.*** 