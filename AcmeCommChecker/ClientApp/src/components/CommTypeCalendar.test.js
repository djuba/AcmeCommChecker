import React from 'react';
import ReactDOM from 'react-dom';
import { MemoryRouter } from 'react-router-dom';
import CommTypeCalendar from './CommTypeCalendar';

it('renders without crashing', async () => {
    const div = document.createElement('div');
    const calendarEvents = {
        className = "test",
        commTypeName = "Phone",
        cssClasses = "test",
        end = "2020-06-04T19:00:00-05:00",
        start = "2020-06-04T16:00:00-05:00",
        temp = 83.77,
        weatherId = 803
    }
    ReactDOM.render(
        <MemoryRouter>
            <CommTypeCalendar calendarEvents={calendarEvents} />
        </MemoryRouter>, div);
    await new Promise(resolve => setTimeout(resolve, 1000));
});