CREATE TABLE IF NOT EXISTS public.authors
(
    id serial not null primary key,
    name text not null,
    surname text not null,
    affiliation text
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.authors
    OWNER to postgres;

CREATE TABLE IF NOT EXISTS public.publishers
(
    id serial not null primary key,
    name text not null
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.publishers
    OWNER to postgres;

CREATE TABLE IF NOT EXISTS public.publishing_places
(
    id serial not null primary key,
    name text not null,
    region text not null,
    country text not null
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.publishing_places
    OWNER to postgres;

CREATE TABLE IF NOT EXISTS public.publication_types
(
    id serial not null primary key,
    type text not null
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.publication_types
    OWNER to postgres;

CREATE TABLE IF NOT EXISTS public.publisher_places
(
    id serial not null primary key,
    publisher integer not null references publishers(id),
    place integer not null references publishing_places(id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.publisher_places
    OWNER to postgres;

CREATE TABLE IF NOT EXISTS public.printed_publications
(
    id serial not null primary key,
    title text not null,
    pages integer not null,
    year integer not null,
    type integer not null references publication_types(id),
    publishing integer not null references publisher_places(id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.printed_publications
    OWNER to postgres;

CREATE TABLE IF NOT EXISTS public.authors_publications
(
    id serial not null primary key,
    publication integer not null references printed_publications(id),
    author integer not null references authors(id),
    author_order integer not null
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.authors_publications
    OWNER to postgres;