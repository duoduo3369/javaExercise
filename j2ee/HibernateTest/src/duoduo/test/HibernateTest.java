package duoduo.test;

import static org.junit.Assert.*;

import java.util.List;

import junit.framework.Assert;

import org.hibernate.HibernateException;
import org.hibernate.Session;
import org.hibernate.Transaction;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;

import duoduo.bean.User;
import duoduo.bean.User;
import duoduo.db.HibernateSessionFactory;

public class HibernateTest {
	Session session = null;

	@Before
	public void setUp() throws Exception {
		session = HibernateSessionFactory.getSession();
	}

	@After
	public void tearDown() throws Exception {
		session.close();
	}

	//@Test
	public void testInsert() {
		User user = new User();
		Transaction tx = session.beginTransaction();
		user.setName("新数据");
		try {

			session.save(user);
			tx.commit();
		} catch (Exception e) {
			tx.rollback();
			fail("插入数据失败");
			e.printStackTrace();
		}
		Assert.assertEquals(user.getId() >= 0, true);
	}
	@Test
	public void testSelect() {
		String hql = "from User where name='新数据'";
		try
		{
			List list = session.createQuery(hql).list();
			User user = (User) list.get(0);
			Assert.assertEquals(user.getName(),"新数据");
		}catch(HibernateException e){
			e.printStackTrace();
			fail(e.getMessage());
		}		
	}
	
	@Test
	public void testGet(){
		User user = (User) session.get(User.class, 1);
		Assert.assertEquals(user.getId()==1, true);
	}

}
