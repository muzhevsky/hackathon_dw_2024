import { observer } from "mobx-react-lite";
import { useContext, useMemo } from "react";
import { Context } from "../..";
import AddScholarship from "./AddScholarship";
import ScholarshipCard from "./ScholarshipCard";

const Scholarship: React.FC = observer(() => {
    const {scholarshipStore, userStore} = useContext(Context);

    const items = useMemo(() => scholarshipStore.idsScholar, [scholarshipStore.idsScholar.length]);

    return(
        <div>
            <AddScholarship/>
            <>
            {
                items.map((item, index) => {
                    <ScholarshipCard key={index} id={item} userId={Number(userStore.user?.id) ?? 1} rejected={false}/>
                })
            }
            </>
        </div>
    )
})

export default Scholarship;