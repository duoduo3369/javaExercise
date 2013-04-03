use skbanji;

-- insert into user (username,password,email) values ('duoduo','duoduo','1@163.com');
-- insert into user (username,password,email) values ('123','duoduo','1@163.com');
-- insert into user (username,password,email) values ('eqwriu','duoduo','1@163.com');
-- insert into user (username,password,email) values ('aaa','duoduo','1@163.com');
-- insert into user (username,password,email) values ('ZEWA','duoduo','1@163.com');


insert into test_constraint (user_id) values (7);

ALTER TABLE user MODIFY COLUMN email VARCHAR(60) NOT NULL;
