create database lk;

\c lk;

create table users
(
    id            serial
        constraint id
            primary key,
    login         varchar(128) not null
        constraint unique_email_pk
            unique,
    surname       varchar(64)  not null,
    name          varchar(64)  not null,
    patronymic    varchar(64),
    password_hash varchar(256) not null,
    salt          varchar(128)
);

alter table users
    owner to postgres;

create table achievements
(
    id        serial
        constraint achievements_id
            primary key,
    user_id   integer not null
        constraint achievements_users_fk
            references users,
    file_name varchar(256),
    score     integer not null,
    team_size integer not null
);

alter table achievements
    owner to postgres;

create table customization_items
(
    id        serial
        constraint customization_items_pk
            primary key,
    title     varchar(128) not null,
    price     integer      not null,
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

create table rejections
(
    id         serial
        constraint rejections_pk
            primary key,
    request_id integer not null
        constraint rejections_requests_fk
            references requests,
    date       date    not null,
    reason     text    not null
);

alter table rejections
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
    id               serial
        constraint news_pk
            primary key,
    title            varchar(256)                   not null,
    publication_date timestamp default CURRENT_DATE not null,
    content          text                           not null
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
            references events,
    id       serial
        constraint news_and_events_pk
            primary key
);

alter table news_and_events
    owner to postgres;

create table institutes
(
    id    serial
        constraint institutes_pk
            primary key,
    title varchar(16) not null
);

alter table institutes
    owner to postgres;

create table departments
(
    id           serial
        constraint departments_pk
            primary key,
    institute_id integer     not null
        constraint departments_institutes_fk
            references institutes,
    title        varchar(16) not null
);

alter table departments
    owner to postgres;

create table groups
(
    id            serial
        constraint groups_pk
            primary key,
    department_id integer     not null
        constraint groups_departments_fk
            references groups,
    title         varchar(16) not null
);

alter table groups
    owner to postgres;

create table students
(
    id           serial
        constraint students_pk
            primary key,
    student_id   varchar(16) not null,
    group_id     integer     not null
        constraint students_groups_fk
            references groups,
    telegram_id  varchar(64),
    user_id      integer     not null
        constraint students_users_fk
            references users,
    phone_number varchar(16)
);

alter table students
    owner to postgres;

create table teachers
(
    user_id       integer not null
        constraint teachers_users_fk
            references users,
    department_id integer not null
        constraint teachers_departments_fk
            references departments
);

alter table teachers
    owner to postgres;

create table users_and_events
(
    user_id  integer not null
        constraint users_and_events_users_fk
            references users,
    event_id integer not null
        constraint users_and_events_event_fk
            references events,
    id       serial
        constraint users_and_events_pk
            primary key
);

alter table users_and_events
    owner to postgres;





insert into institutes(title) values('ИнПИТ');
insert into departments(institute_id, title) values (1, 'ПИТ');
insert into groups(department_id, title) values (1, 'б1-ИФСТ-31');