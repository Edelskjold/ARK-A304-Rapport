
INSERT INTO example
  (field1, field2, field3)
  VALUES
  ('test', 'N', NULL);
 
 
 
UPDATE example
  SET field1 = 'updated value'
  WHERE field2 = 'N';
 
 
 
DELETE FROM example
  WHERE field2 = 'N';
