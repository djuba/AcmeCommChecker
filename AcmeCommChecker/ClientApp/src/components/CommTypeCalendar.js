import React, { Component } from "react";

import ReactDOM from "react-dom";

import FullCalendar from "@fullcalendar/react";
import timeGrid from "@fullcalendar/timegrid";

import "@fullcalendar/core/main.css";
import "@fullcalendar/daygrid/main.css";
import "@fullcalendar/timegrid/main.css";
import "../css/owfont-regular.css";

export class CommTypeCalendar extends Component {
    static displayName = CommTypeCalendar.name;


    render() {
        const header = {
            left: '',
            center: 'title',
            right: ''
        };

        const plugins = [timeGrid];

        const views = {
            timeGridFiveDay: {
                type: 'timeGrid',
                duration: { days: 5 }
            }
        };

        return (
            <div>
                <FullCalendar
                    defaultView="timeGridFiveDay"
                    header={header}
                    plugins={plugins}
                    views={views}
                    slotDuration="01:00:00"
                    slotLabelInterval="01:00:00"
                    events={this.props.calendarEvents}
                    eventRender={this.customEventRender}
                />
            </div>
        );
    }

    customEventRender = info => {
        let iconClass = "owf owf-lg owf-" + info.event.extendedProps.weatherId;
        let badgeClass = "badge float-right";
        if (info.event.extendedProps.commTypeName === "Phone") {
            badgeClass += " badge-primary";
        } else if (info.event.extendedProps.commTypeName === "Email") {
            badgeClass += " badge-success";
        } else if (info.event.extendedProps.commTypeName === "SMS") {
            badgeClass += " badge-warning";
        }

        ReactDOM.render(
            <div className="fc-content">
                <span className="fc-title">{Math.round(info.event.extendedProps.temp)}°F</span><i className={iconClass}></i><span className={badgeClass}>{info.event.extendedProps.commTypeName}</span>
            </div>,
            info.el,
        );
        return info.el
    }
}