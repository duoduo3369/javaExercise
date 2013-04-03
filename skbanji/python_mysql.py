import MySQLdb
 
try:
    conn=MySQLdb.connect(host='127.0.0.1',user='root',passwd='duoduo',db='skbanji',port=3306)
    cur=conn.cursor()
    cur.execute('select * from user')
    cur.close()
    conn.close()
except MySQLdb.Error,e:
     print "Mysql Error %d: %s" % (e.args[0], e.args[1])
