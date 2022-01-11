/*
Created: 05.01.2022
Modified: 09.01.2022
Model: phys_01
Database: PostgreSQL 12
*/

-- Create functions section -------------------------------------------------
DROP SCHEMA if exists public CASCADE;
CREATE SCHEMA public;

-- Table student

CREATE TABLE "student"
(
  "student_pk" Serial NOT NULL,
  "login" Text NOT NULL,
  "password" Text NOT NULL,
  "lastname" Text NOT NULL,
  "firstname" Text NOT NULL,
  "patronymic" Text
)
WITH (
  autovacuum_enabled=true)
;

ALTER TABLE "student" ADD CONSTRAINT "PK_student" PRIMARY KEY ("student_pk")
;

ALTER TABLE "student" ADD CONSTRAINT "student_key" UNIQUE ("student_pk")
;

ALTER TABLE "student" ADD CONSTRAINT "student_login_key" UNIQUE ("login")
;

-- Table teacher

CREATE TABLE "teacher"
(
  "teacher_pk" Serial NOT NULL,
  "lastname" Text NOT NULL,
  "firstname" Text NOT NULL,
  "patronymic" Text,
  "login" Text NOT NULL,
  "password" Text NOT NULL
)
WITH (
  autovacuum_enabled=true)
;

ALTER TABLE "teacher" ADD CONSTRAINT "PK_teacher" PRIMARY KEY ("teacher_pk")
;

ALTER TABLE "teacher" ADD CONSTRAINT "teacher_login_key" UNIQUE ("teacher_pk")
;

ALTER TABLE "teacher" ADD CONSTRAINT "teacher_login_uniq" UNIQUE ("login")
;

-- Table gradebook

CREATE TABLE "gradebook"
(
  "gradebook_pk" Serial NOT NULL,
  "number" Text NOT NULL,
  "student_pk" Integer NOT NULL,
  "group_pk" Integer
)
WITH (
  autovacuum_enabled=true)
;

CREATE INDEX "IX_group_for_gradebook" ON "gradebook" ("group_pk")
;

ALTER TABLE "gradebook" ADD CONSTRAINT "PK_gradebook" PRIMARY KEY ("gradebook_pk","student_pk")
;

ALTER TABLE "gradebook" ADD CONSTRAINT "gradebook_key" UNIQUE ("gradebook_pk")
;

ALTER TABLE "gradebook" ADD CONSTRAINT "gradebook_number_key" UNIQUE ("number")
;

-- Table study_group

CREATE TABLE "study_group"
(
  "group_pk" Serial NOT NULL,
  "number" Text NOT NULL,
  "study_plan_pk" Integer NOT NULL,
  "speciality_pk" Integer NOT NULL
)
WITH (
  autovacuum_enabled=true)
;

CREATE INDEX "IX_plan_for_group" ON "study_group" ("study_plan_pk","speciality_pk")
;

ALTER TABLE "study_group" ADD CONSTRAINT "Unique_Identifier1" PRIMARY KEY ("group_pk")
;

ALTER TABLE "study_group" ADD CONSTRAINT "group_key" UNIQUE ("group_pk")
;

ALTER TABLE "study_group" ADD CONSTRAINT "group_number_uniq" UNIQUE ("number")
;

-- Table speciality

CREATE TABLE "speciality"
(
  "speciality_pk" Serial NOT NULL,
  "name" Text NOT NULL
)
WITH (
  autovacuum_enabled=true)
;

ALTER TABLE "speciality" ADD CONSTRAINT "PK_speciality" PRIMARY KEY ("speciality_pk")
;

ALTER TABLE "speciality" ADD CONSTRAINT "spec_key" UNIQUE ("speciality_pk")
;

ALTER TABLE "speciality" ADD CONSTRAINT "name" UNIQUE ("name")
;

-- Table result

CREATE TABLE "result"
(
  "result_pk" Serial NOT NULL,
  "gradebook_pk" Integer NOT NULL,
  "student_pk" Integer NOT NULL,
  "ticket_pk" Integer NOT NULL,
  "statement_header_pk" Integer NOT NULL,
  "grade" Integer,
  "data" Date NOT NULL,
  "is_active" Boolean DEFAULT True NOT NULL
)
WITH (
  autovacuum_enabled=true)
;
create or replace function set_time_trigger() returns trigger
as $$
begin
        update "statement_header" set "data" = curdate() where "statement_header_pk" = NEW."statement_header_pk";
        return NEW;
    end
$$ language plpgsql;


CREATE INDEX "IX_ticket_for_result" ON "result" ("ticket_pk")
;

CREATE INDEX "IX_header_for_result" ON "result" ("statement_header_pk")
;

CREATE INDEX "IX_gradebook_for_result" ON "result" ("gradebook_pk","student_pk")
;

ALTER TABLE "result" ADD CONSTRAINT "PK_result" PRIMARY KEY ("result_pk")
;

ALTER TABLE "result" ADD CONSTRAINT "result_key" UNIQUE ("result_pk")
;

-- Table study_plan

CREATE TABLE "study_plan"
(
  "study_plan_pk" Serial NOT NULL,
  "speciality_pk" Integer NOT NULL,
  "plan_number" Text NOT NULL
)
WITH (
  autovacuum_enabled=true)
;

ALTER TABLE "study_plan" ADD CONSTRAINT "PK_study_plan" PRIMARY KEY ("study_plan_pk","speciality_pk")
;

ALTER TABLE "study_plan" ADD CONSTRAINT "study_plan_key" UNIQUE ("study_plan_pk")
;

ALTER TABLE "study_plan" ADD CONSTRAINT "Номер плана" UNIQUE ("plan_number")
;

-- Table ticket

CREATE TABLE "ticket"
(
  "ticket_pk" Serial NOT NULL,
  "number_tick" Bigint NOT NULL,
  "discipline_pk" Integer NOT NULL
)
WITH (
  autovacuum_enabled=true)
;

CREATE INDEX "IX_Relationship1" ON "ticket" ("discipline_pk")
;

ALTER TABLE "ticket" ADD CONSTRAINT "PK_ticket" PRIMARY KEY ("ticket_pk")
;

ALTER TABLE "ticket" ADD CONSTRAINT "Ключ билета" UNIQUE ("ticket_pk")
;

-- Table answer_to_task

CREATE TABLE "answer_to_task"
(
  "answer_pk" Serial NOT NULL,
  "answer" Text NOT NULL,
  "task_in_test_pk" Integer NOT NULL,
  "result_pk" Integer NOT NULL,
  "ticket_pk" Integer NOT NULL
)
WITH (
  autovacuum_enabled=true)
;

ALTER TABLE "answer_to_task" ADD CONSTRAINT "PK_answer_to_task" PRIMARY KEY ("answer_pk","result_pk","task_in_test_pk","ticket_pk")
;

ALTER TABLE "answer_to_task" ADD CONSTRAINT "Ключ ответа" UNIQUE ("answer_pk")
;

-- Table task_in_test

CREATE TABLE "task_in_test"
(
  "task_in_test_pk" Serial NOT NULL,
  "task_pk" Integer NOT NULL,
  "ticket_pk" Integer NOT NULL
)
WITH (
  autovacuum_enabled=true)
;

CREATE INDEX "IX_task_for_testtask" ON "task_in_test" ("task_pk")
;

ALTER TABLE "task_in_test" ADD CONSTRAINT "PK_task_in_test" PRIMARY KEY ("task_in_test_pk","ticket_pk")
;

ALTER TABLE "task_in_test" ADD CONSTRAINT "Ключ тестового задания" UNIQUE ("task_in_test_pk")
;

-- Table statement_header

CREATE TABLE "statement_header"
(
  "statement_header_pk" Serial NOT NULL,
  "number" Text NOT NULL,
  "data" Date NOT NULL,
  "entry_in_study_statement_pk" Integer NOT NULL,
  "study_statement_header_pk" Integer NOT NULL
)
WITH (
  autovacuum_enabled=true)
;

CREATE INDEX "IX_statement_header_for_entry" ON "statement_header" ("entry_in_study_statement_pk","study_statement_header_pk")
;

ALTER TABLE "statement_header" ADD CONSTRAINT "PK_statement_header" PRIMARY KEY ("statement_header_pk")
;

ALTER TABLE "statement_header" ADD CONSTRAINT "Ключ шапки ведомости" UNIQUE ("statement_header_pk")
;

ALTER TABLE "statement_header" ADD CONSTRAINT "Номер ведомости" UNIQUE ("number")
;

-- Table task

CREATE TABLE "task"
(
  "task_pk" Serial NOT NULL,
  "answers" Text NOT NULL,
  "right_answer" Text NOT NULL,
  "topic_pk" Integer NOT NULL,
  "question" Text NOT NULL,
  "name" Text NOT NULL
)
WITH (
  autovacuum_enabled=true)
;

CREATE INDEX "IX_topic_for_task" ON "task" ("topic_pk")
;

ALTER TABLE "task" ADD CONSTRAINT "PK_task" PRIMARY KEY ("task_pk")
;

ALTER TABLE "task" ADD CONSTRAINT "Ключ задания" UNIQUE ("task_pk")
;

-- Table department

CREATE TABLE "department"
(
  "department_pk" Serial NOT NULL,
  "name" Text NOT NULL
)
WITH (
  autovacuum_enabled=true)
;

ALTER TABLE "department" ADD CONSTRAINT "PK_department" PRIMARY KEY ("department_pk")
;

ALTER TABLE "department" ADD CONSTRAINT "Ключ кафедры" UNIQUE ("department_pk")
;

ALTER TABLE "department" ADD CONSTRAINT "Наименование" UNIQUE ("name")
;

-- Table study_statement_header

CREATE TABLE "study_statement_header"
(
  "study_statement_header_pk" Serial NOT NULL,
  "teacher_pk" Integer NOT NULL,
  "department_pk" Integer NOT NULL
)
WITH (
  autovacuum_enabled=true)
;

CREATE INDEX "IX_teacher_for_statement" ON "study_statement_header" ("teacher_pk")
;

CREATE INDEX "IX_department_for_statement" ON "study_statement_header" ("department_pk")
;

ALTER TABLE "study_statement_header" ADD CONSTRAINT "PK_study_statement_header" PRIMARY KEY ("study_statement_header_pk")
;

-- Table entry_in_study_statement

CREATE TABLE "entry_in_study_statement"
(
  "entry_in_study_statement_pk" Serial NOT NULL,
  "discipline_pk" Integer NOT NULL,
  "study_statement_header_pk" Integer NOT NULL,
  "group_pk" Integer
)
WITH (
  autovacuum_enabled=true)
;

CREATE INDEX "IX_group_for_entry" ON "entry_in_study_statement" ("group_pk")
;

CREATE INDEX "IX_discipline_for_statement_entry" ON "entry_in_study_statement" ("discipline_pk")
;

ALTER TABLE "entry_in_study_statement" ADD CONSTRAINT "PK_entry_in_study_statement" PRIMARY KEY ("entry_in_study_statement_pk","study_statement_header_pk")
;

ALTER TABLE "entry_in_study_statement" ADD CONSTRAINT "Ключ записи в учебном поручении" UNIQUE ("entry_in_study_statement_pk")
;

-- Table topic

CREATE TABLE "topic"
(
  "topic_pk" Serial NOT NULL,
  "name" Text NOT NULL,
  "discipline_pk" Integer NOT NULL
)
WITH (
  autovacuum_enabled=true)
;

CREATE INDEX "IX_discipline_for_topic" ON "topic" ("discipline_pk")
;

ALTER TABLE "topic" ADD CONSTRAINT "PK_topic" PRIMARY KEY ("topic_pk")
;

ALTER TABLE "topic" ADD CONSTRAINT "Ключ темы" UNIQUE ("topic_pk")
;

-- Table discipline

CREATE TABLE "discipline"
(
  "discipline_pk" Serial NOT NULL,
  "name" Text NOT NULL
)
WITH (
  autovacuum_enabled=true)
;

ALTER TABLE "discipline" ADD CONSTRAINT "PK_discipline" PRIMARY KEY ("discipline_pk")
;

ALTER TABLE "discipline" ADD CONSTRAINT "Ключ дисциплины" UNIQUE ("discipline_pk")
;

ALTER TABLE "discipline" ADD CONSTRAINT "name_uniq" UNIQUE ("name")
;

-- Table entry_in_study_plan

CREATE TABLE "entry_in_study_plan"
(
  "entry_in_study_plan_pk" Serial NOT NULL,
  "study_plan_pk" Integer NOT NULL,
  "speciality_pk" Integer NOT NULL,
  "discipline_pk" Integer NOT NULL
)
WITH (
  autovacuum_enabled=true)
;

CREATE INDEX "IX_discipline_of_entry" ON "entry_in_study_plan" ("discipline_pk")
;

ALTER TABLE "entry_in_study_plan" ADD CONSTRAINT "PK_entry_in_study_plan" PRIMARY KEY ("entry_in_study_plan_pk","study_plan_pk","speciality_pk")
;

ALTER TABLE "entry_in_study_plan" ADD CONSTRAINT "Ключ записи в учебном плане" UNIQUE ("entry_in_study_plan_pk")
;

-- Table admin

CREATE TABLE "admin"
(
  "login" Text NOT NULL,
  "password" Text NOT NULL,
  "admin_pk" Serial NOT NULL,
  "firstname" Text NOT NULL,
  "lastname" Text NOT NULL,
  "patronimyc" Text
)
WITH (
  autovacuum_enabled=true)
;

ALTER TABLE "admin" ADD CONSTRAINT "PK_admin" PRIMARY KEY ("admin_pk")
;

ALTER TABLE "admin" ADD CONSTRAINT "Логин" UNIQUE ("login")
;

ALTER TABLE "admin" ADD CONSTRAINT "ключ пдминистратора" UNIQUE ("admin_pk")
;

-- Create foreign keys (relationships) section -------------------------------------------------

ALTER TABLE "gradebook"
  ADD CONSTRAINT "student_for_gradebook"
    FOREIGN KEY ("student_pk")
    REFERENCES "student" ("student_pk")
      ON DELETE CASCADE
      ON UPDATE CASCADE
;

ALTER TABLE "gradebook"
  ADD CONSTRAINT "group_for_gradebook"
    FOREIGN KEY ("group_pk")
    REFERENCES "study_group" ("group_pk")
      ON DELETE RESTRICT
      ON UPDATE CASCADE
;

ALTER TABLE "study_plan"
  ADD CONSTRAINT "plan_for_speciality"
    FOREIGN KEY ("speciality_pk")
    REFERENCES "speciality" ("speciality_pk")
      ON DELETE CASCADE
      ON UPDATE CASCADE
;

ALTER TABLE "entry_in_study_plan"
  ADD CONSTRAINT "entry_in_plane"
    FOREIGN KEY ("study_plan_pk", "speciality_pk")
    REFERENCES "study_plan" ("study_plan_pk", "speciality_pk")
      ON DELETE CASCADE
      ON UPDATE CASCADE
;

ALTER TABLE "study_group"
  ADD CONSTRAINT "plan_for_group"
    FOREIGN KEY ("study_plan_pk", "speciality_pk")
    REFERENCES "study_plan" ("study_plan_pk", "speciality_pk")
      ON DELETE RESTRICT
      ON UPDATE CASCADE
;

ALTER TABLE "entry_in_study_statement"
  ADD CONSTRAINT "group_for_entry"
    FOREIGN KEY ("group_pk")
    REFERENCES "study_group" ("group_pk")
      ON DELETE RESTRICT
      ON UPDATE CASCADE
;

ALTER TABLE "entry_in_study_statement"
  ADD CONSTRAINT "discipline_for_statement_entry"
    FOREIGN KEY ("discipline_pk")
    REFERENCES "discipline" ("discipline_pk")
      ON DELETE RESTRICT
      ON UPDATE CASCADE
;

ALTER TABLE "topic"
  ADD CONSTRAINT "discipline_for_topic"
    FOREIGN KEY ("discipline_pk")
    REFERENCES "discipline" ("discipline_pk")
      ON DELETE CASCADE
      ON UPDATE CASCADE
;

ALTER TABLE "task"
  ADD CONSTRAINT "topic_for_task"
    FOREIGN KEY ("topic_pk")
    REFERENCES "topic" ("topic_pk")
      ON DELETE CASCADE
      ON UPDATE CASCADE
;

ALTER TABLE "study_statement_header"
  ADD CONSTRAINT "teacher_for_statement"
    FOREIGN KEY ("teacher_pk")
    REFERENCES "teacher" ("teacher_pk")
      ON DELETE RESTRICT
      ON UPDATE CASCADE
;

ALTER TABLE "study_statement_header"
  ADD CONSTRAINT "department_for_statement"
    FOREIGN KEY ("department_pk")
    REFERENCES "department" ("department_pk")
      ON DELETE RESTRICT
      ON UPDATE CASCADE
;

ALTER TABLE "entry_in_study_statement"
  ADD CONSTRAINT "study_statement_header_for_entry"
    FOREIGN KEY ("study_statement_header_pk")
    REFERENCES "study_statement_header" ("study_statement_header_pk")
      ON DELETE CASCADE
      ON UPDATE CASCADE
;

ALTER TABLE "statement_header"
  ADD CONSTRAINT "statement_header_for_entry"
    FOREIGN KEY ("entry_in_study_statement_pk", "study_statement_header_pk")
    REFERENCES "entry_in_study_statement" ("entry_in_study_statement_pk", "study_statement_header_pk")
      ON DELETE RESTRICT
      ON UPDATE CASCADE
;

ALTER TABLE "task_in_test"
  ADD CONSTRAINT "task_for_testtask"
    FOREIGN KEY ("task_pk")
    REFERENCES "task" ("task_pk")
      ON DELETE CASCADE
      ON UPDATE CASCADE
;

ALTER TABLE "task_in_test"
  ADD CONSTRAINT "ticket_for_testtask"
    FOREIGN KEY ("ticket_pk")
    REFERENCES "ticket" ("ticket_pk")
      ON DELETE CASCADE
      ON UPDATE CASCADE
;

ALTER TABLE "answer_to_task"
  ADD CONSTRAINT "task_for_answer"
    FOREIGN KEY ("task_in_test_pk", "ticket_pk")
    REFERENCES "task_in_test" ("task_in_test_pk", "ticket_pk")
      ON DELETE RESTRICT
      ON UPDATE CASCADE
;

ALTER TABLE "answer_to_task"
  ADD CONSTRAINT "result_for_answer"
    FOREIGN KEY ("result_pk")
    REFERENCES "result" ("result_pk")
      ON DELETE CASCADE
      ON UPDATE CASCADE
;

ALTER TABLE "result"
  ADD CONSTRAINT "gradebook_for_result"
    FOREIGN KEY ("gradebook_pk", "student_pk")
    REFERENCES "gradebook" ("gradebook_pk", "student_pk")
      ON DELETE CASCADE
      ON UPDATE CASCADE
;

ALTER TABLE "result"
  ADD CONSTRAINT "ticket_for_result"
    FOREIGN KEY ("ticket_pk")
    REFERENCES "ticket" ("ticket_pk")
      ON DELETE RESTRICT
      ON UPDATE RESTRICT
;

ALTER TABLE "result"
  ADD CONSTRAINT "header_for_result"
    FOREIGN KEY ("statement_header_pk")
    REFERENCES "statement_header" ("statement_header_pk")
      ON DELETE RESTRICT
      ON UPDATE CASCADE
;

ALTER TABLE "entry_in_study_plan"
  ADD CONSTRAINT "discipline_of_entry"
    FOREIGN KEY ("discipline_pk")
    REFERENCES "discipline" ("discipline_pk")
      ON DELETE RESTRICT
      ON UPDATE CASCADE
;

ALTER TABLE "ticket"
  ADD CONSTRAINT "dist_for_tick"
    FOREIGN KEY ("discipline_pk")
    REFERENCES "discipline" ("discipline_pk")
      ON DELETE RESTRICT
      ON UPDATE CASCADE
;



-- Create function section -------------------------------------------------
/*Добавление специальности*/
create or replace function add_speciality(name1 text) returns integer as $$
declare
    id_spec speciality.speciality_pk%TYPE;
begin
    insert into speciality(name) values (name1)
    returning speciality_pk into  id_spec;
    return id_spec;
    EXCEPTION
        when others then
            raise EXCEPTION 'Не удалось создать специальность %, ошибка: %', name1, SQLERRM;
end
$$ language plpgsql;
/*тест
 select * from add_speciality('Приборостроение');*/

/*Добавление учебного плана*/
create or replace function add_study_plan(number_of_plan text, id_spec integer) returns integer
as $$
declare
    name_spec speciality.name%TYPE;
    id_plan study_plan.study_plan_pk%TYPE;
begin
 
select name from speciality where speciality_pk = id_spec into name_spec;
    If not FOUND then
        raise Exception 'Специальность % не найдена', name_spec;
    end if;
 select study_plan_pk from study_plan where speciality_pk = id_spec and plan_number = number_of_plan into id_plan;
    If FOUND then
        raise Exception 'План % уже существует для специальности "%"', number_of_plan, name_spec;
    end if;
    insert into study_plan (plan_number, speciality_pk) values (number_of_plan, id_spec)
    returning study_plan_pk into id_plan;
  raise INFO 'Учебный план % для специальности "%" создан',  number_of_plan, name_spec;
    return id_plan;
    EXCEPTION
        when others then
            raise EXCEPTION 'Не удалось создать учебный план, ошибка: %', SQLERRM;
end
$$ language plpgsql;

/*Добавление дисциплины*/
create or replace function add_discipline(name1 text) returns integer as $$
declare
    id_disc discipline.discipline_pk%TYPE;
begin
    insert into discipline(name) values (name1)
    returning discipline_pk into  id_disc;
    raise INFO 'Дисциплина % добавлена', name1;
    return id_disc;
    EXCEPTION
        when others then
            raise EXCEPTION 'Не удалось создать дисциплину %, ошибка: %', name1, SQLERRM;
end
$$ language plpgsql;
/*тест
select * from add_discipline('Основы программирования');
*/
/*Добавление пользователя (студента или преподавателя)*/
create or replace function add_user(firstname text, lastname text, patronymic text, us_login text, password text, user_type text) returns integer as $$
declare
    student_id student.student_pk%TYPE;
    teacher_id teacher.teacher_pk%TYPE;
begin
/*Проверка на уникальность логина*/
    select student_pk from student where login = us_login into student_id;
    select teacher_pk from teacher where login = us_login into teacher_id;
     if student_id IS NOT NULL or teacher_id IS NOT NULL then
        raise EXCEPTION 'пользователь с логином % уже существует.', us_login;
    end if;
/*Непосредственно добавление пользователя*/
    if user_type='student' then
        insert into student(login, password, lastname, firstname, patronymic) values (us_login, password, lastname, firstname, patronymic)
        returning student_pk into student_id;
        raise INFO 'Пользователь % % создан',  firstname, lastname;
        return student_id;
    elsif user_type='teacher' then
        insert into teacher(login, password, lastname, firstname, patronymic) values (us_login, password, lastname, firstname, patronymic)
        returning teacher_pk into teacher_id;
        raise INFO 'Пользователь % % создан',  firstname, lastname;
        return teacher_id;
    else raise EXCEPTION 'неверный тип пользователя %', user_type;
    end if;
   
    EXCEPTION
        when others then
            raise EXCEPTION 'Не удалось создать пользователя % %, ошибка: %', firstname, lastname, SQLERRM;
end
$$ language plpgsql;

/*Добавление записи учебного плана*/
create or replace function add_entry_in_study_plan(study_plan_pk1 integer, discipline_pk1 integer) returns integer
as $$
declare
    id_spec speciality.speciality_pk%TYPE;
    disc_name discipline.name%TYPE;
  id_entry entry_in_study_plan.entry_in_study_plan_pk%TYPE;
begin
 
select name from discipline where discipline_pk = discipline_pk1 into disc_name;
    If not FOUND then
        raise Exception 'Дисциплина не найдена';
    end if;
 
 select speciality_pk from study_plan
 where study_plan_pk = study_plan_pk1 into id_spec;
    If not FOUND then
        raise Exception 'Указанный учебный план не найден';
    end if;
 select entry_in_study_plan_pk from entry_in_study_plan where study_plan_pk= study_plan_pk1 and discipline_pk = discipline_pk1 into id_entry;
    If FOUND then
        raise Exception 'Такая запись уже существует в плане';
    end if;
    insert into entry_in_study_plan(study_plan_pk, speciality_pk, discipline_pk)
  values ( study_plan_pk1, id_spec, discipline_pk1)
    returning entry_in_study_plan_pk into id_entry;
raise INFO 'Запись % учебного плана создана',disc_name;
 
    return id_entry;
    EXCEPTION
        when others then
            raise EXCEPTION 'Не удалось добавить запись в учебный план, ошибка: %', SQLERRM;
end
$$ language plpgsql;
 
/*Добавление кафедры*/
create or replace function add_department(name1 text) returns integer as $$
declare
    id_dep department.department_pk%TYPE;
begin
    insert into department(name) values (name1)
    returning department_pk into  id_dep;
    return id_dep;
    EXCEPTION
        when others then
            raise EXCEPTION 'Не удалось создать кафедру %, ошибка: %', name1, SQLERRM;
end
$$ language plpgsql;

/*Добавление темы дисциплины*/
create or replace function add_topic(id_disc integer, topic_name text) returns integer as $$
declare
    discipline_name discipline.name%TYPE;
    topic_id topic.name%TYPE;
 
begin
    select name from discipline into discipline_name where discipline_pk = id_disc;
        if not found then raise EXCEPTION 'дисциплина "%" не существует', discipline_name;
        end if;
    select topic_pk from topic into topic_id where name = topic_name and discipline_pk = id_disc;
        if found then raise EXCEPTION 'тема "%" уже добавлена в дисциплину "%"', topic_name, discipline_name;
        end if;
       
    insert into topic(name, discipline_pk) values (topic_name, id_disc)
    returning topic_pk into topic_id;
    raise INFO'Тема "%" добавлена в дисциплину "%" ', topic_name, discipline_name;
    return topic_id;
    EXCEPTION
        when others then
            raise EXCEPTION 'Не удалось добавить тему, ошибка: %', SQLERRM;
end
$$ language plpgsql;

/*Добавление группы*/
create or replace function add_group(id_plan integer, number_group text) returns integer
as $$
declare
    id_spec speciality.speciality_pk%TYPE;
    id_group study_group.group_pk%TYPE;
begin
 select speciality_pk  from study_plan
 where study_plan_pk = id_plan into id_spec;
    If not FOUND then
        raise Exception 'Учебный план не найден';
    end if;
    insert into study_group(number, study_plan_pk, speciality_pk)
  values (number_group, id_plan, id_spec)
    returning group_pk into id_group;
raise INFO 'Группа % создана', number_group;
    return id_group;
    EXCEPTION
        when others then
            raise EXCEPTION 'Не удалось создать группу %, ошибка: %', number_group, SQLERRM;
end
$$ language plpgsql;

/*Добавление вопроса по теме*/
create or replace function add_task(topic_id integer, question text, answers text, right_answer text, task_name text) returns integer as $$
declare
    id_topic topic.topic_pk%TYPE;
    name_topic topic.name%TYPE;
    id_task task.task_pk%TYPE;
begin  
    select name from topic where topic_pk = topic_id into name_topic;
    if not found then raise exception 'Указана несуществующая тема';
    end if;
    insert into task(question, answers, right_answer, topic_pk, name) values (question, answers, right_answer, topic_id, task_name)
    returning task_pk into id_task;
    raise INFO'Вопрос "%" добавлен в тему "%" ', task_name, name_topic;
    return id_task;
    EXCEPTION
        when others then
            raise EXCEPTION 'Не удалось добавить, ошибка: %', SQLERRM;
end
$$ language plpgsql;

/*Создание шапки билета*/
create or replace function add_ticket(id_disc integer, ticket_number integer) returns integer as $$
declare
    discipline_name discipline.name%TYPE;
    ticket_id ticket.ticket_pk%TYPE;
 
begin
    select name from discipline into discipline_name where discipline_pk = id_disc;
        if not found then raise EXCEPTION 'дисциплина "%" не существует', discipline_name;
        end if;
    select ticket_pk from ticket into ticket_id where number_tick = ticket_number and discipline_pk = id_disc;
        if found then raise EXCEPTION 'билет №% уже добавлен в дисциплину "%"', ticket_number, discipline_name;
        end if;
       
    insert into ticket(number_tick, discipline_pk) values (ticket_number, id_disc)
    returning ticket_pk into ticket_id;
    raise INFO'Билет №"%" добавлен в дисциплину "%" ', ticket_number, discipline_name;
    return ticket_id;
    EXCEPTION
        when others then
            raise EXCEPTION 'Не удалось добавить билет, ошибка: %', SQLERRM;
end
$$ language plpgsql;
/*Добавление студента в группу*/
drop function if exists add_student_in_group(text, integer, integer);
create or replace function add_student_in_group(gradebook_num text, student_pk1 integer, group_pk1 integer) returns integer
as $$
declare
  str text;
    id_gradebook gradebook.gradebook_pk%TYPE;
begin
 
select login from student where student_pk = student_pk1 into str;
    If not FOUND then
        raise Exception 'Студент не найден';
    end if;
select number from study_group where group_pk = group_pk1 into str;
    If not FOUND then
        raise Exception 'Группа не найдена';
    end if;  
 
 select gradebook_pk from gradebook where student_pk = student_pk1 and group_pk= group_pk1 into id_gradebook;
    If FOUND then
        raise Exception 'Студент уже числится в указанной группе';
    end if;
    insert into gradebook(number, student_pk, group_pk)
  values (gradebook_num, student_pk1, group_pk1)
    returning gradebook_pk into id_gradebook;
raise INFO 'Студeнт добавлен в группу';
    return id_gradebook;
    EXCEPTION
        when others then
            raise EXCEPTION 'Не удалось добавить студента в группу, ошибка: %', SQLERRM;
end
$$ language plpgsql;
 
 /*Добавление учебного поручения*/
 create or replace function add_study_statement_header(teacher_pk1 integer, department_pk1 integer) returns integer
as $$
declare
  str text;
    id_study_statement_header study_statement_header.study_statement_header_pk%TYPE;
begin
 
select login from teacher where teacher_pk = teacher_pk1 into str;
    If not FOUND then
        raise Exception 'Преподаватель не найден';
    end if;
select name from department where department_pk = department_pk1 into str;
    If not FOUND then
        raise Exception 'Кафедра не найдена';
    end if;  
 
    insert into study_statement_header(teacher_pk, department_pk)
  values (teacher_pk1, department_pk1)
    returning study_statement_header_pk into id_study_statement_header;
raise INFO 'Поручение добавлено';
    return id_study_statement_header;
    EXCEPTION
        when others then
            raise EXCEPTION 'Не удалось добавить поручение, ошибка: %', SQLERRM;
end
$$ language plpgsql;
/*Добавление тестового задания в билет*/
create or replace function add_task_in_test(task_id integer, ticket_id integer) returns integer as $$
declare
    discipline_id discipline.discipline_pk%TYPE;
    discipline_id_in_task discipline.discipline_pk%TYPE;
    topic_id topic.topic_pk%TYPE;
    ticket_number ticket.number_tick%TYPE;
    task_name task.name%TYPE;
begin
    select discipline_pk, number_tick from ticket into discipline_id, ticket_number where ticket_pk = ticket_id;
    select topic_pk, name from  task into topic_id, task_name where task_pk = task_id;
    select discipline_pk from topic into discipline_id_in_task where topic_pk = topic_id;
        if discipline_id != discipline_id_in_task then raise EXCEPTION 'вопрос и билет имеют разные дисциплины';
        end if;
    /*добавляем задание*/
    insert into task_in_test(task_pk, ticket_pk) values (task_id, ticket_id)
    returning task_in_test_pk into ticket_id;
    raise INFO'Вопрос "%" добавлен в билет №"%" ', ticket_number, task_name;
    return ticket_id;
    EXCEPTION
        when others then
            raise EXCEPTION 'Не удалось добавить вопрос в билет, ошибка: %', SQLERRM;
end
$$ language plpgsql;

/*Добавление записи учебного поручения*/
create or replace function add_entry_in_study_statement
(study_statement_header_pk1 integer, discipline_pk1 integer, group_pk1 integer) returns integer
as $$
declare
  str text;
  num integer;
    id_entry entry_in_study_statement.entry_in_study_statement_pk%TYPE;
begin
 
select study_statement_header_pk from study_statement_header where study_statement_header_pk = study_statement_header_pk1 into num;
    If not FOUND then
        raise Exception 'Поручение не найдено';
    end if;
select name from discipline where discipline_pk = discipline_pk1 into str;
    If not FOUND then
        raise Exception 'Дисциплина не найдена';
    end if;  
select group_pk from study_group where  group_pk =  group_pk1 into num;
    If not FOUND then
        raise Exception 'Группа не найдена';
    end if;
 
select entry_in_study_statement_pk from entry_in_study_statement
where  study_statement_header_pk = study_statement_header_pk1 and
discipline_pk=discipline_pk1 and
group_pk=group_pk1 into num;
    If FOUND then
        raise Exception 'Такая запись уже существует';
    end if;
    insert into entry_in_study_statement(study_statement_header_pk, discipline_pk, group_pk)
  values (study_statement_header_pk1, discipline_pk1, group_pk1)
    returning entry_in_study_statement_pk into id_entry;
raise INFO 'Запись добавлена в поручение';
    return id_entry;
    EXCEPTION
        when others then
            raise EXCEPTION 'Не удалось добавить запись в поручение поручение, ошибка: %', SQLERRM;
end
$$ language plpgsql;
 /*Создать шапку ведомости*/
drop function if exists add_statement_header(text, integer);
create or replace function add_statement_header(statement_number text, study_statement_entry_id integer) returns integer
as $$
declare
   study_statement_header_id study_statement_header.study_statement_header_pk%TYPE;
  statement_header_id statement_header.statement_header_pk%TYPE;
begin
  select study_statement_header_pk from entry_in_study_statement into study_statement_header_id
  where entry_in_study_statement_pk = study_statement_entry_id;
    insert into statement_header(number, entry_in_study_statement_pk, study_statement_header_pk)
  values (statement_number, study_statement_entry_id, study_statement_header_id)
    returning statement_header_pk into statement_header_id;
  raise INFO 'Ведомость добавлена';
    return statement_header_id;
    EXCEPTION
        when others then
            raise EXCEPTION 'Не удалось добавить ведомость, ошибка: %', SQLERRM;
end
$$ language plpgsql;

/*Добавить результат аттестации*/
create or replace function add_result(gradebook_id integer, ticket_id integer, statement_id integer) returns integer
as $$
declare
  stud_id student.student_pk%TYPE;
   res_id result.result_pk%TYPE;
  group_in_stat integer;
  group_in_gradebook integer;
  study_entry integer;
begin
  select student_pk, group_pk from gradebook into stud_id, group_in_gradebook where gradebook_pk = gradebook_id;
  select entry_in_study_statement_pk into study_entry from statement_header where statement_header_pk = statement_id;  
  select group_pk into group_in_stat from entry_in_study_statement where entry_in_study_statement_pk = study_entry;
  if group_in_stat != group_in_gradebook then
    raise exception 'Студент не числится в группе, указанной в ведомости';
  end if;
  /*непосредственно, добавление*/
    insert into result(gradebook_pk, student_pk, ticket_pk, statement_header_pk)
   values (gradebook_id, stud_id, ticket_id, statement_id)
    returning result_pk into res_id;
  raise INFO 'Создан результат аттестации';
    return res_id;
    EXCEPTION
        when others then
            raise EXCEPTION 'Не удалось добавить результат, ошибка: %', SQLERRM;
end
$$ language plpgsql;

/*Добавить запись в результат аттестации*/
create or replace function add_answer(result_id integer, task_in_test_id integer, stud_answer text) returns integer
as $$
declare
    ticket_id integer;
    ticket_inres_id integer;
    answer_id integer;
begin
    select ticket_pk into ticket_id from task_in_test where task_in_test_pk = task_in_test_id;
    select ticket_pk into ticket_inres_id
    from result where result_pk = result_id;
    if ticket_id != ticket_inres_id then
    raise exception 'Задание не содержится в билете';
    end if;
    /*непосредственно, добавление*/
    insert into answer_to_task(answer, result_pk, task_in_test_pk, ticket_pk)
    values (stud_answer, result_id, task_in_test_id, ticket_id)
    returning answer_pk into answer_id;
    raise INFO 'Ответ добавлен';
    return answer_id;
    EXCEPTION
        when others then
            raise EXCEPTION 'Не удалось добавить ответ, ошибка: %', SQLERRM;
end
$$ language plpgsql;

/*Удаление студента*/
create or replace procedure delete_student(student_pk1 integer)
as $$
begin
delete from student where student_pk=student_pk1;
EXCEPTION
        when others then
            raise EXCEPTION 'Не удалось удалить объект, ошибка: %', SQLERRM;
 
end
$$ language plpgsql;

/*Удаление билета*/
create or replace procedure delete_ticket(ticket_pk1 integer)
as $$
begin
delete from ticket where ticket_pk =ticket_pk1;
EXCEPTION
        when others then
            raise EXCEPTION 'Не удалось удалить объект, ошибка: %', SQLERRM;
end
$$ language plpgsql;
 
/*Удаление группы*/
create or replace procedure delete_study_group(group_pk1 integer)
as $$
begin
delete from study_group where group_pk=group_pk1;
EXCEPTION
        when others then
            raise EXCEPTION 'Не удалось удалить объект, ошибка: %', SQLERRM;
 
end
$$ language plpgsql;
 
/*Удаление преподавателя*/
create or replace procedure delete_teacher(teacher_pk1 integer)
as $$
begin
delete from teacher where teacher_pk =teacher_pk1;
EXCEPTION
        when others then
            raise EXCEPTION 'Не удалось удалить объект, ошибка: %', SQLERRM;
 
end
$$ language plpgsql;
 
/*Удаление дисциплины*/
 
create or replace procedure delete_discipline(discipline_pk1 integer)
as $$
begin
delete from discipline where discipline_pk =discipline_pk1;
EXCEPTION
        when others then
            raise EXCEPTION 'Не удалось удалить объект, ошибка: %', SQLERRM;
 
end
$$ language plpgsql;
/*Удаление задания*/
create or replace procedure delete_task(task_pk1 integer)
as $$
begin
delete from task where task_pk =task_pk1;
EXCEPTION
        when others then
            raise EXCEPTION 'Не удалось удалить объект, ошибка: %', SQLERRM;
end
$$ language plpgsql;
 
/*Обновление пароля студента*/
create or replace procedure update_student_pass(student_pk1 bigint, password1 text)
   language plpgsql
as $$
declare
begin
    update student set   password = password1
                            where student_pk = student_pk1;
EXCEPTION
        when others then
            raise EXCEPTION 'Не удалось изменить данные, ошибка: %',  SQLERRM;
end
$$;
 
/*Триггерная функция для автоматической установки текущего времени в столбец data*/
create or replace function set_time_trigger() returns trigger
as $$
begin
        NEW.data := current_date;
        return NEW;
    end
$$ language plpgsql;
 
/*Непосредственно, триггер на установку времени  для результата аттестации*/
CREATE TRIGGER set_time
    BEFORE INSERT
    ON public.result
    FOR EACH ROW
    EXECUTE FUNCTION public.set_time_trigger();
/*Для ведомости*/
CREATE TRIGGER set_time
    BEFORE INSERT
    ON public.statement_header
    FOR EACH ROW
    EXECUTE FUNCTION public.set_time_trigger();

------------create view
create or replace view student_view as 
    select student_pk as id, lastname as lastname, 
	firstname as firtname, patronymic as patronymic
    from student;
select * from student_view;
 

select * from add_speciality('Приборостроение');
select * from add_study_plan('№3456', 1); 
select * from add_discipline('Основы программирования');
select * from add_discipline('Правоведение');
select * from add_discipline('Безопасность жизнедеятельности');
select * from add_discipline('Философия');
select * from add_user('Иван', 'Иванов', 'Иванович', 'vanya91', '1234', 'student');
select * from add_user('Алевтина', 'Алабаева', 'Александровна', 'alya009', '1234', 'student');
select * from add_user('Борис', 'Баранов', 'Борисович', 'borisboris', '1234', 'student');
select * from add_user('Петр', 'Петров', 'Петрович', 'petr91', '1234', 'teacher');
select * from add_entry_in_study_plan(1, 1);
select * from add_department('Прикладная математика');
select * from add_topic(1, 'Оператор switch');
select * from add_group(1, 'ps12');
select * from add_task(1, 'Сколько бит в байте?', '1 - 3; 2 - 8;', '2', '№1');
select * from add_ticket(1, 1);
select * from add_student_in_group('ps23123', 1, 1);
select * from add_study_statement_header(1, 1);
select * from add_task_in_test(1, 1);
select * from add_entry_in_study_statement(1, 1, 1);
select * from add_statement_header('12', 1);
select * from add_result(1, 1, 1);
select * from add_answer(1, 1, '1');