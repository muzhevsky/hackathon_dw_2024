import axios from "axios";
import { useEffect } from "react";


const App: React.FC = () => {
  useEffect(() => {
    const response = axios.get(`http://localhost:8080/hello`, {
      withCredentials: true
  });
    response.then(response => {
      console.log(response);
    })
  }, [])

  return(
    <>
    </>
  )
}

export default App;
