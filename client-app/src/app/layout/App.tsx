import { Fragment } from 'react';
import {  Container} from 'semantic-ui-react';
import NavBar from './NavBar';
import { useStore } from '../stores/store';
import { observer } from 'mobx-react-lite';
import { Outlet, useLocation } from 'react-router-dom';
import HomePage from '../../features/home/HomePage';
import {ToastContainer} from 'react-toastify'

function App()  {

const location =useLocation();


  return (
  <Fragment>

 <ToastContainer position='bottom-right' theme='colored'/>
    {location.pathname === '/' ?< HomePage/>:(

     <>
   <NavBar ></NavBar>
   <Container style={{marginTop:'7em'}}>

   <Outlet></Outlet>
   </Container>
     </>
    )}
   
    </Fragment>
  );
}

export default observer(App) ;
