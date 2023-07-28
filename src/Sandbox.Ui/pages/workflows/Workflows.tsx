import DashboardLayout from "../../components/layouts/DashboardLayout";
import { WorkflowCommandBar } from "./components/workflow-command-bar/WorkflowCommandBar";
import { ScheduledWorkflowBar } from "./components/scheduled-workflow-bar/ScheduledWorkflowBar";
import { WorkflowContainer } from "./components/workflow-container/WorkflowContainer";

function Workflows() {
    const userID = "0";
    return (
        <DashboardLayout>
            <span>Let's automate things!</span>
            <WorkflowContainer userID={userID}></WorkflowContainer>
            <div style={{ marginTop: "auto" }}>
                <WorkflowCommandBar></WorkflowCommandBar>
                <ScheduledWorkflowBar></ScheduledWorkflowBar>
            </div>
        </DashboardLayout>
    );
}

export default Workflows;
