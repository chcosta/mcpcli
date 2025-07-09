# AI Planning System Flow Diagram

## 🎯 **Overview**

This diagram shows how the AI planning system works in the MCP CLI tool, from user prompt to final execution.

## 🔄 **System Flow**

```
┌─────────────────┐
│   User Prompt   │
│   "initialize   │
│   client and    │
│   get projects" │
└─────────┬───────┘
          │
          ▼
┌─────────────────┐
│  Preview Mode   │
│   Check?        │
└─────────┬───────┘
          │
    ┌─────┴─────┐
    │           │
    ▼           ▼
┌─────────┐ ┌─────────┐
│   NO    │ │   YES   │
│ Simple  │ │  AI     │
│ Mode    │ │Planning │
└────┬────┘ └────┬────┘
     │           │
     ▼           ▼
┌─────────┐ ┌─────────┐
│Direct   │ │AI Plan  │
│Tool     │ │Generation│
│Execution│ │         │
└────┬────┘ └────┬────┘
     │           │
     │           ▼
     │    ┌─────────────┐
     │    │ 1. Analyze  │
     │    │    Prompt   │
     │    │ 2. Discover │
     │    │    Tools    │
     │    │ 3. Generate │
     │    │    Steps    │
     │    └──────┬──────┘
     │           │
     │           ▼
     │    ┌─────────────┐
     │    │ 4. Validate │
     │    │    Plan     │
     │    │ 5. Save to  │
     │    │  Markdown   │
     │    └──────┬──────┘
     │           │
     │           ▼
     │    ┌─────────────┐
     │    │ 6. Execute  │
     │    │    Plan     │
     │    │ 7. Track    │
     │    │  Progress   │
     │    └──────┬──────┘
     │           │
     │           ▼
     │    ┌─────────────┐
     │    │ 8. Generate │
     │    │   Response  │
     │    └──────┬──────┘
     │           │
     ▼           ▼
┌─────────────────────────┐
│    Final Response       │
│    to User              │
└─────────────────────────┘
```

## 🔧 **Detailed Component Flow**

### **1. Mode Selection**
```
User Request → Check Preview Features Flag → Choose Execution Mode
```

**Preview Features Disabled (Simple Mode):**
- Direct tool execution
- No AI planning
- Immediate tool calls
- Faster execution

**Preview Features Enabled (AI Planning Mode):**
- AI-powered plan generation
- Step-by-step execution
- Progress tracking
- Context management

### **2. AI Planning Process**

```
┌─────────────────┐
│  User Prompt    │
└─────────┬───────┘
          │
          ▼
┌─────────────────┐
│  AI Analysis    │
│ • Parse prompt  │
│ • Identify goals│
│ • Find tools    │
└─────────┬───────┘
          │
          ▼
┌─────────────────┐
│ Tool Discovery  │
│ • List servers  │
│ • Map tools     │
│ • Check enabled │
└─────────┬───────┘
          │
          ▼
┌─────────────────┐
│ Plan Generation │
│ • Create steps  │
│ • Set order     │
│ • Add context   │
└─────────┬───────┘
          │
          ▼
┌─────────────────┐
│ Plan Validation │
│ • Check tools   │
│ • Verify steps  │
│ • Fix issues    │
└─────────┬───────┘
          │
          ▼
┌─────────────────┐
│ Save to Files   │
│ • plan.md       │
│ • step-*.md     │
└─────────┬───────┘
          │
          ▼
┌─────────────────┐
│ Execute Plan    │
└─────────────────┘
```

### **3. Plan Execution Flow**

```
┌─────────────────┐
│   Load Plan     │
└─────────┬───────┘
          │
          ▼
┌─────────────────┐
│  For Each Step  │
└─────────┬───────┘
          │
          ▼
┌─────────────────┐
│ Check Dependencies│
│ • Previous steps│
│ • Conditions    │
└─────────┬───────┘
          │
          ▼
┌─────────────────┐
│ Execute Tool    │
│ • Call server   │
│ • Pass params   │
│ • Get result    │
└─────────┬───────┘
          │
          ▼
┌─────────────────┐
│ Save Results    │
│ • Update step   │
│ • Store context │
└─────────┬───────┘
          │
          ▼
┌─────────────────┐
│ Next Step?      │
└─────────┬───────┘
    ┌─────┴─────┐
    │           │
    ▼           ▼
┌─────────┐ ┌─────────┐
│   NO    │ │   YES   │
│Generate │ │ Continue│
│Response │ │         │
└────┬────┘ └────┬────┘
     │           │
     ▼           │
┌─────────┐      │
│ Final   │      │
│Response │      │
└─────────┘      │
                 │
                 ▼
         ┌─────────────┐
         │  Loop Back  │
         └─────────────┘
```

## 📁 **File Structure**

```
.plans/
├── {timestamp}-{prompt-hash}/
│   ├── plan.md                    # Master plan with all steps
│   ├── step-001-initialize.md     # Step 1 execution details
│   ├── step-002-get-projects.md   # Step 2 execution details
│   └── execution-summary.md       # Final execution summary
```

## 🔍 **Key Components**

### **1. Plan Generator (`AiPlanGenerator`)**
- Analyzes user prompt
- Discovers available tools
- Creates execution steps
- Validates plan structure

### **2. Plan Executor (`AdvancedPlanExecutor`)**
- Executes steps sequentially
- Handles dependencies
- Manages context flow
- Tracks progress

### **3. Plan Persistence (`PlanPersistenceService`)**
- Saves plans to markdown files
- Stores step results
- Maintains execution history

### **4. Context Manager (`StepContextManager`)**
- Reads previous step results
- Manages data flow between steps
- Handles context injection

## ⚡ **Performance Comparison**

| Mode | Speed | Complexity | Accuracy | Debugging |
|------|-------|------------|----------|-----------|
| **Simple Mode** | Fast | Low | High | Limited |
| **AI Planning** | Slower | High | Variable | Excellent |

## 🎯 **When to Use Each Mode**

### **Use Simple Mode When:**
- Quick, direct tool execution needed
- Known tool names and parameters
- No complex dependencies
- Performance is critical

### **Use AI Planning When:**
- Complex multi-step workflows
- Unknown tool requirements
- Need execution history
- Want detailed debugging
- Complex context management needed

## 🔧 **Configuration**

```yaml
# Enable AI planning
preview_features: true

# Or disable for simple mode
preview_features: false
```

## 🚀 **Example Flow**

**User Prompt:** "initialize the client and tell me all the projects in the dnceng organization"

**AI Planning Mode:**
1. Analyze prompt → Identify need for initialization and project retrieval
2. Discover tools → Find `initialize_azure_dev_ops_client` and `get_projects`
3. Generate plan → Create 2-step execution plan
4. Execute plan → Run steps sequentially with context
5. Generate response → AI creates final response from results

**Simple Mode:**
1. Direct execution → Immediately call `initialize_azure_dev_ops_client`
2. Direct execution → Immediately call `get_projects`
3. Return results → Direct tool output

---

*This diagram shows the complete flow of the AI planning system, from user input to final execution, highlighting the differences between simple and AI planning modes.* 