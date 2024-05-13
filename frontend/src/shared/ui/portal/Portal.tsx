import { ReactElement } from "react";
import { createPortal } from "react-dom";

interface PortalProps {
    children: ReactElement;
}

const Portal: React.FC<PortalProps> = ({ children }) => {

    return createPortal(
        <div>
            {
                children
            }
        </div>, document.body);
}

export default Portal;