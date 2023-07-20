import { Grid } from "semantic-ui-react";
import ActivityList from "./ActivityList";
import { useStore } from "../../../app/stores/store";
import { observer } from "mobx-react-lite";
import LoadingComponent from "../../../app/layout/LoadingComponents";
import { useEffect } from "react";


export default observer( function ActivityDashboard(){ 

    const {activityStore} =useStore()
    const {loadActivities,activityRegistry} = activityStore;

    useEffect(()=>{
       if(activityRegistry.size ===0)loadActivities();
      },[loadActivities])
    
    
      if(activityStore.loadingInitial) return <LoadingComponent content='Loading app'/>

    return( 
    <Grid>
        <Grid.Column width='10'>
         <ActivityList/>
        </Grid.Column>
        <Grid.Column width='6'>
        <h1>Activity filters</h1>
        </Grid.Column>
    </Grid>)
   
})

