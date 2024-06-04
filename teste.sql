--
-- PostgreSQL database dump
--

-- Dumped from database version 15.7
-- Dumped by pg_dump version 15.7

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: registrar_log_delete(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.registrar_log_delete() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO log_operacoes (operacao) VALUES ('DELETE');
    RETURN OLD;
END;
$$;


ALTER FUNCTION public.registrar_log_delete() OWNER TO postgres;

--
-- Name: registrar_log_insert(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.registrar_log_insert() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO log_operacoes (operacao) VALUES ('INSERT');
    RETURN NEW;
END;
$$;


ALTER FUNCTION public.registrar_log_insert() OWNER TO postgres;

--
-- Name: registrar_log_update(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.registrar_log_update() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO log_operacoes (operacao) VALUES ('UPDATE');
    RETURN NEW;
END;
$$;


ALTER FUNCTION public.registrar_log_update() OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: cadastros; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.cadastros (
    campotexto character varying(200) NOT NULL,
    camponum integer NOT NULL,
    CONSTRAINT cadastros_txtnum_check CHECK ((camponum > 0))
);


ALTER TABLE public.cadastros OWNER TO postgres;

--
-- Name: log_operacoes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.log_operacoes (
    operacao character varying(50) NOT NULL,
    data_hora timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);


ALTER TABLE public.log_operacoes OWNER TO postgres;

--
-- Data for Name: cadastros; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.cadastros (campotexto, camponum) FROM stdin;
\.


--
-- Data for Name: log_operacoes; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.log_operacoes (operacao, data_hora) FROM stdin;
INSERT	2024-06-04 17:36:43.684683
UPDATE	2024-06-04 17:37:12.586805
DELETE	2024-06-04 17:37:22.203082
\.


--
-- Name: cadastros cadastros_txtnum_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.cadastros
    ADD CONSTRAINT cadastros_txtnum_key UNIQUE (camponum);


--
-- Name: cadastros tr_log_delete; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER tr_log_delete AFTER DELETE ON public.cadastros FOR EACH ROW EXECUTE FUNCTION public.registrar_log_delete();


--
-- Name: cadastros tr_log_insert; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER tr_log_insert AFTER INSERT ON public.cadastros FOR EACH ROW EXECUTE FUNCTION public.registrar_log_insert();


--
-- Name: cadastros tr_log_update; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER tr_log_update AFTER UPDATE ON public.cadastros FOR EACH ROW EXECUTE FUNCTION public.registrar_log_update();


--
-- PostgreSQL database dump complete
--

