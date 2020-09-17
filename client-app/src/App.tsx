import React, { Component } from "react";
import "./App.css";
import axios from "axios";
import { Button, Header, Icon, List } from "semantic-ui-react";

interface IAppProps {}
interface IAppState {
  values: Array<{ id: number; name: string }>;
  loading: boolean;
  disabled: boolean;
}

class App extends Component {
  state: IAppState = {
    values: [],
    loading: false,
    disabled: false,
  };

  componentDidMount() {
    axios.get("http://localhost:5000/api/values").then((response) => {
      this.setState({
        values: response.data,
      });
    });
  }

  handleRefresh = () => {
    this.setState({
      loading: !this.state.loading,
      disabled: !this.state.disabled,
    });

    axios.get("http://localhost:5000/api/values").then((response) => {
      this.setState({
        values: response.data,
        loading: false,
        disabled: false,
      });
    });
  };

  render() {
    return (
      <div>
        <Header as="h2">
          <Icon name="user"/>
          <Header.Content>Reactivities</Header.Content>
        </Header>
        <List>
            {this.state.values.map((value: any) => (
              <List.Item key={value.id}>{value.name}</List.Item>
            ))}
          </List>
      </div>
    );
  }
}

export default App;