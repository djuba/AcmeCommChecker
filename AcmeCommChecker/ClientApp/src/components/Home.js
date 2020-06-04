import React, { Component } from 'react';

import { CommTypeCalendar } from './CommTypeCalendar.js';
import * as moment from 'moment';

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = { calendarEvents: [], loading: true };

        this.handleSubmit = this.handleSubmit.bind(this);
    }

    async handleSubmit(e) {
        e.preventDefault();
        const url = 'commtypecalendar?location=' + document.getElementById('location').value;
        const response = await fetch(url);
        const data = await response.json();
        data.map(this.setCalendarEventProperties);
        this.setState({ calendarEvents: data, loading: false });
    }

    setCalendarEventProperties(calendarEvent) {
        calendarEvent.start = moment.utc(calendarEvent.startUtc).local().format();
        calendarEvent.end = moment.utc(calendarEvent.endUtc).local().format();
        calendarEvent.classNames = calendarEvent.cssClasses;
        calendarEvent.title = `${calendarEvent.temp}`;
    }

    render () {
        return (
            <div>
                <div className="row">
                    <form className="form-inline" onSubmit={this.handleSubmit}>
                        <div className="form-group mb-2">
                            <input type="text" id="location" name="search" className="form-control" placeholder="Minneapolis,MN,US" />
                        </div>
                        <button type="submit" className="btn btn-outline-primary mx-sm-3 mb-2">Search</button>
                    </form>
                </div>
                <div className="row mb-5">
                    <small className="form-text text-muted">
                        Search by City,Country or City,State,Country if location is in US.
                    </small>
                </div>
                <div className="row">
                    <CommTypeCalendar calendarEvents={this.state.calendarEvents} loading={this.state.loading} />
                </div>
            </div>
        );
    }
}
