create database lk;

\c lk;    

create table roles
(
    id    serial
        constraint roles_pk
            primary key,
    title varchar(32) not null
        constraint roles_unique_titie_pk_2
            unique
);

alter table roles
    owner to postgres;

create table users
(
    id            serial
        constraint id
            primary key,
    email         varchar(128) not null
        constraint unique_email_pk
            unique,
    surname       varchar(64)  not null,
    name          varchar(64)  not null,
    patronymic    varchar(64),
    password_hash varchar(256) not null,
    salt          varchar(128),
    role_id       integer      not null
        constraint users_roles_id_fk
            references roles
);

alter table users
    owner to postgres;

create table achievements
(
    id             serial
        constraint achievements_id
            primary key,
    user_id        integer      not null
        constraint achievements_users_fk
            references users,
    filename       varchar(256) not null,
    score          integer      not null
);

alter table achievements
    owner to postgres;

create table customization_items
(
    id        serial
        constraint customization_items_pk
            primary key,
    title varchar(128) not null,
    file_path varchar(128) not null
);

alter table customization_items
    owner to postgres;

create table user_items
(
    id      serial,
    item_id integer not null,
    count   integer not null
);

alter table user_items
    owner to postgres;

create table requests
(
    id       serial
        constraint requests_pk
            primary key,
    user_id  integer not null
        constraint requests_users_fk
            references users,
    rejected boolean not null
);

alter table requests
    owner to postgres;

create table rejection_reasons
(
    id         serial
        constraint rejection_reasons_pk
            primary key,
    request_id integer not null
        constraint rejection_reasons_requests_fk
            references requests,
    reason     text    not null
);

alter table rejection_reasons
    owner to postgres;

create table requests_and_achievements
(
    request_id     integer not null
        constraint requests_and_achievements_requests_fk
            references requests,
    achievement_id integer not null
        constraint requests_and_achievements_achievements_fk
            references achievements
);

alter table requests_and_achievements
    owner to postgres;

create table news
(
    id      serial
        constraint news_pk
            primary key,
    title   varchar(256) not null,
    publication_date timestamp not null default current_date,
    content text         not null
);

alter table news
    owner to postgres;

create table event_statuses
(
    id    serial
        constraint event_statuses_pk
            primary key,
    title varchar(64) not null
);

alter table event_statuses
    owner to postgres;

create table events
(
    id          serial
        constraint events_pk
            primary key,
    title       varchar(256) not null,
    start_date  date         not null,
    end_date    date         not null,
    status_id   integer      not null
        constraint events_statuses_fk
            references event_statuses,
    description text         not null,
    constraint events_check_date
        check (end_date > start_date)
);

alter table events
    owner to postgres;

create table users_and_events
(
    user_id   integer not null
        constraint users_and_events_users_fk
            references users,
    events_id integer not null
        constraint users_and_events_events_fk
            references events
);

alter table users_and_events
    owner to postgres;

create table achievements_and_events
(
    achievement_id integer not null
        constraint achievements_and_events_achievements_fk
            references achievements,
    event_id       integer not null
        constraint achievements_and_events_events_fk
            references events
);

alter table achievements_and_events
    owner to postgres;

create table pinned_news
(
    news_id serial
        constraint pinned_news_pk
            primary key
);

alter table pinned_news
    owner to postgres;

create table news_and_events
(
    news_id  integer not null
        constraint news_and_events_news_fk
            references news,
                
    event_id integer not null
        constraint news_and_events_event_fk
            references events
);

alter table news_and_events
    owner to postgres;



insert into roles(title) values ('user'), ('admin'), ('deanery');
insert into users(email, surname, name, patronymic, password_hash, salt, role_id)
values ('some@email.ru', 'someSurname', 'someName', null, '123321', '321321', (select id from roles where title='user'));
