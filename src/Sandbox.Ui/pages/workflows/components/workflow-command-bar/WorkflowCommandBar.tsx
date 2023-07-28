import { WorkflowCommand } from '../workflow-command/WorkflowCommand';
import { Command } from '../workflow-command/WorkflowCommandProps';
import '../workflow-command/WorkflowCommandStyles.scss'

export const WorkflowCommandBar: React.FC = () => {

    return(
        <div className='workflow-command-bar'>
            <WorkflowCommand command={Command.Create}></WorkflowCommand>
             <WorkflowCommand command={Command.Schedule}></WorkflowCommand>
             <WorkflowCommand command={Command.Create}></WorkflowCommand>
             <WorkflowCommand command={Command.Schedule}></WorkflowCommand>
             <WorkflowCommand command={Command.Create}></WorkflowCommand>
             <WorkflowCommand command={Command.Schedule}></WorkflowCommand>
             <WorkflowCommand command={Command.Create}></WorkflowCommand>
             <WorkflowCommand command={Command.Schedule}></WorkflowCommand>
        </div>
    );

}