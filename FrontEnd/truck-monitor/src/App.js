import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import {BootstrapTable, TableHeaderColumn} from 'react-bootstrap-table';

var myInit1 = { method: 'POST', 
                mode: 'cors'
              };
class App extends Component {

  constructor(props){
    super(props)
    this.state = {
      Token:{
        token: []
      },
      truckData: {
        customerTrucks: []
      }
    }
  }

  fetchTruckData = () => {
    var myHeaders = new Headers();
    myHeaders.append("Authorization",this.state.Token)
    var myInit2 = {
                  method: 'GET',
                  mode: 'cors',
                  headers: myHeaders
                };
    
    setInterval( () => {
      fetch('http://truckapi.azurewebsites.net/api/Trucks', myInit2)
      .then( response => {return response.json()} )
      .then( resource => {
        this.setState({
          truckData: resource
        })
      })
    }, 10000 )
  }

  componentDidMount() {
    fetch('http://truckapi.azurewebsites.net/api/Token',myInit1)
    .then( response => {return response.json()} )
    .then( resource => {
      this.setState({
        Token: `Bearer ${resource.token}`
      }, () => {
        this.fetchTruckData();
      })
    })
    
  }

  render() {
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">Scania Truck Monitor</h1>
        </header>
        <p className="App-intro">
          Here you will be able to monitor trucks owned by your customers
        </p>

        <BootstrapTable data={ this.state.truckData.customerTrucks } search={ true }>
        <TableHeaderColumn dataField='vehicleId' isKey> Vehicle ID </TableHeaderColumn>
        <TableHeaderColumn dataField='customerCompanyName'> Customer Company Name </TableHeaderColumn>
        <TableHeaderColumn dataField='adress'>adress</TableHeaderColumn>
        <TableHeaderColumn dataField='regNr'>Reg Nr</TableHeaderColumn>
        <TableHeaderColumn dataField='truckConnectionStatus'>Truck Connection Status</TableHeaderColumn>
        </BootstrapTable>

        </div>
    );
  }
}

export default App;
