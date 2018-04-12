
DROP TABLE Note CASCADE CONSTRAINTS PURGE;
DROP SEQUENCE NOTE_SEQ ;

CREATE SEQUENCE NOTE_SEQ 
INCREMENT BY 1 
START WITH 1
MAXVALUE 10000000000000000000000000000000000000
MINVALUE 1
NOCACHE  
NOCYCLE
NOORDER
;

CREATE TABLE Note
(
	NoteId               NUMBER NOT NULL ,
	Title                VARCHAR2(50) NOT NULL ,
	Contents             VARCHAR2(2000) NULL ,
	CreatedDate          DATE NOT NULL ,
	CONSTRAINT  PK_Note PRIMARY KEY (NoteId)
);


insert into note (noteid, title, contents, createddate) values (note_seq.nextval, '타이틀', '내용입니다.', sysdate );
insert into note (noteid, title, contents, createddate) values (note_seq.nextval, '타이틀2', '내용입니다.2', sysdate );
insert into note (noteid, title, contents, createddate) values (note_seq.nextval, '타이틀3', '내용입니다.3', sysdate );
insert into note (noteid, title, contents, createddate) values (note_seq.nextval, '타이틀4', '내용입니다.4', sysdate );
insert into note (noteid, title, contents, createddate) values (note_seq.nextval, '타이틀5', '내용입니다.5', sysdate );
insert into note (noteid, title, contents, createddate) values (note_seq.nextval, '타이틀6', '내용입니다.6', sysdate );
insert into note (noteid, title, contents, createddate) values (note_seq.nextval, '타이틀7', '내용입니다.7', sysdate );
insert into note (noteid, title, contents, createddate) values (note_seq.nextval, '타이틀8', '내용입니다.8', sysdate );
insert into note (noteid, title, contents, createddate) values (note_seq.nextval, '타이틀9', '내용입니다.9', sysdate );

commit;
