import { makeAutoObservable } from "mobx";
import { Event } from "../entities/event/Event";
import { EventForCabinet } from "../entities/event/EventForCabinet";

class EventsStore{
    private _events: EventForCabinet[] = [];

    constructor(){
        makeAutoObservable(this);
    }

    get events() {
        return this._events;
    }

    set events(events: EventForCabinet[]){
        this._events = events;
    }
}

export default EventsStore;