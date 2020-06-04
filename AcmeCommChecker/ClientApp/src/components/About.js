import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';

export class About extends Component {
    static displayName = About.name;

  render () {
    return (
        <div>
            <h1>Welcome</h1>
            <p>
                This handy dandy little SPA uses the OpenWeather 5 day / 3 hour API to give you a 5 day calendar for displaying the optimal communication method for contacting your customers based on the following proven criteria:
                <ul>
                    <li>The best time to engage a customer via a text message is when it is sunny and warmer than 75 degrees Fahrenheit.</li>
                    <li>The best time to engage a customer via email is when it is between 55 and 75 degrees Fahrenheit.</li>
                    <li>The best time to engage a customer via a phone call is when it is less than 55 degrees or when it is raining.</li>
                </ul>
            </p>
      </div>
    );
  }
}
