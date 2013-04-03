-- phpMyAdmin SQL Dump
-- version 3.3.8.1
-- http://www.phpmyadmin.net
--
-- 主机: w.rdc.sae.sina.com.cn:3307
-- 生成日期: 2013 年 04 月 01 日 13:00
-- 服务器版本: 5.5.23
-- PHP 版本: 5.2.9
use app_skbanji;

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- 数据库: `app_skbanji`
--

-- --------------------------------------------------------

--
-- 表的结构 `article`
--

CREATE TABLE IF NOT EXISTS `article` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(255) NOT NULL,
  `content` longtext NOT NULL,
  `date` varchar(30) NOT NULL,
  `user_id` int(11) NOT NULL,
  `banji_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `article_403f60f` (`user_id`),
  KEY `article_5fedeacb` (`banji_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=7 ;

--
-- 转存表中的数据 `article`
--

INSERT INTO `article` (`id`, `title`, `content`, `date`, `user_id`, `banji_id`) VALUES
(3, 'firtst blog 第一篇日志', '实验一下这个数据库', '2012-10-27 22:15:15', 1, 1),
(4, '第二实验', '<p style="font-family:宋体;font-size:14px;background-color:#FFFFFF;text-indent:30px;">\r\n	<strong>外交部：中方愿与日方友好相处 但有原则底线</strong>\r\n</p>\r\n<p style="font-family:宋体;font-size:14px;background-color:#FFFFFF;text-indent:30px;">\r\n	外交部副部长张志军26日举行<a class="" href="http://news.china.com.cn/txt/2012-10/27/content_26923615.htm" target="_blank"><span>中外媒体吹风会</span></a>，就<span><a href="http://guoqing.china.com.cn/2012-01/17/content_24425021.htm" target="_blank">钓鱼岛</a></span>问题和中日关系阐述了中方立场和主张。张志军表示，中国历来主张通过对话谈判和平解决国际争端。中国不会主动惹事，但也不怕事。我们是有原则、有底线的，在涉及国家领土主权的问题上绝不会退让。据新华社电\r\n</p>\r\n<p style="font-family:宋体;font-size:14px;background-color:#FFFFFF;text-indent:30px;">\r\n	<strong>【主权之争】</strong>\r\n</p>\r\n<p style="font-family:宋体;font-size:14px;background-color:#FFFFFF;text-indent:30px;">\r\n	<strong>钓鱼岛主权争议因日“窃取”</strong>\r\n</p>\r\n<p style="font-family:宋体;font-size:14px;background-color:#FFFFFF;text-indent:30px;">\r\n	张志军表示，钓鱼岛原本不是问题，也不存在什么主权争议。由于1895年日本非法窃取和霸占了钓鱼岛，才出现了问题，形成了争议。无论从历史还是法理角度看，钓鱼岛都是中国的固有领土。\r\n</p>\r\n<p style="font-family:宋体;font-size:14px;background-color:#FFFFFF;text-indent:30px;">\r\n	他说，1972年中日恢复邦交时，双方就将“钓鱼岛问题放一放，留待以后解决”达成谅解和共识。此次日本政府不顾中方坚决反对，宣布“购买”钓鱼岛，严重侵犯中国领土主权，给中日关系带来了邦交正常化40年来最严重的冲击。\r\n</p>\r\n<p style="font-family:宋体;font-size:14px;background-color:#FFFFFF;text-indent:30px;">\r\n	张志军表示，对于日方非法“购岛”行径，中方从一开始就表明了坚决反对的态度。但日本政府对中方的警告置若罔闻，仍然一意孤行，迈出了侵犯中国领土主权的严重升级步骤，激起了中国两岸四地和海内外十几亿中国人的强烈义愤。\r\n</p>\r\n<p style="font-family:宋体;font-size:14px;background-color:#FFFFFF;text-indent:30px;">\r\n	张志军表示，中国政府采取了一系列坚决有力措施捍卫国家领土主权。日方错判了形势，低估了中国政府和人民捍卫国家领土主权的意志和决心。\r\n</p>\r\n<p style="font-family:宋体;font-size:14px;background-color:#FFFFFF;text-indent:30px;">\r\n	<strong>【日本右翼】</strong>\r\n</p>\r\n<p style="font-family:宋体;font-size:14px;background-color:#FFFFFF;text-indent:30px;">\r\n	<strong>历史悲剧重演不是没有可能</strong>\r\n</p>\r\n<p style="font-family:宋体;font-size:14px;background-color:#FFFFFF;text-indent:30px;">\r\n	张志军说，日本没有权利拿中国领土进行任何形式的“买卖”，钓鱼岛寸土滴水、一草一木都不容交易。不管日方以什么形式“购岛”，都是对中国领土主权的严重侵犯。这次“购岛”闹剧是日本右翼势力蓄意挑起的，日本政府对这股势力侵犯中国领土主权、破坏中日关系的行径不仅不加以制止，反而亲自出面“购岛”。右翼想做的事情、想要达到的目的，最终由日本政府一手办了。\r\n</p>\r\n<p style="font-family:宋体;font-size:14px;background-color:#FFFFFF;text-indent:30px;">\r\n	张志军指出，日本右翼势力危险的政治倾向曾经将亚洲拖入巨大的灾难。如果不予以制止，会进一步助长其气焰，使得日本在危险道路上越走越远。这样发展下去，历史悲剧重演不是没有可能。\r\n</p>\r\n<p style="font-family:宋体;font-size:14px;background-color:#FFFFFF;text-indent:30px;">\r\n	张志军强调，日本国内至今对那场侵略战争性质的认识始终是遮遮掩掩，一些政治人物趾高气扬、毫无负罪感和耻辱感走进靖国神社参拜，丝毫不顾及亚洲受害国人民的感情。如果日本不能直面历史，深刻反省，痛改前非，即便经济上再发达，在道义上、精神上也永远站不起来。\r\n</p>\r\n<p align="center" style="font-family:宋体;font-size:14px;background-color:#FFFFFF;">\r\n	<br />\r\n</p>\r\n<p style="font-family:宋体;font-size:14px;background-color:#FFFFFF;text-indent:30px;">\r\n	<strong>【对外政策】</strong>\r\n</p>\r\n<p style="font-family:宋体;font-size:14px;background-color:#FFFFFF;text-indent:30px;">\r\n	<strong>与邻为善前提是尊重主权</strong>\r\n</p>\r\n<p style="font-family:宋体;font-size:14px;background-color:#FFFFFF;text-indent:30px;">\r\n	张志军说，中日之间通过各种渠道和形式就钓鱼岛问题保持着接触和磋商。双方已于9月25日在北京启动了两国副外长钓鱼岛问题磋商。中方在与日方的各层次接触磋商中严肃表明了中国政府在钓鱼岛问题上的严正立场，敦促日方认清形势，放弃幻想，正视现实，以实际行动纠正错误。\r\n</p>\r\n<p style="font-family:宋体;font-size:14px;background-color:#FFFFFF;text-indent:30px;">\r\n	张志军表示，中国历来主张通过对话谈判和平解决国际争端。中国不会主动惹事，但也不怕事。我们愿同包括日本在内的所有国家友好相处，但我们是有原则、有底线的，在涉及国家领土主权的问题上绝不会退让。在钓鱼岛问题上，我们希望通过谈判对话妥善处理有关问题，不希望看到局势失控，但这不取决于中方。日方必须认真对待中方严正立场和重大关切。\r\n</p>\r\n<p style="font-family:宋体;font-size:14px;background-color:#FFFFFF;text-indent:30px;">\r\n	张志军最后表示，中国一贯坚持与邻为善、以邻为伴的睦邻友好政策。但如果有人在领土主权问题上挑战中方的底线，我们没有退路，必须做出强有力的反应，为走稳和平发展道路排除干扰和障碍。【<a class="" href="http://news.china.com.cn/txt/2012-10/28/content_26924838.htm" target="_blank"><span>详细</span></a>】\r\n</p>\r\n<p style="font-family:宋体;font-size:14px;background-color:#FFFFFF;text-indent:30px;">\r\n	<strong>外交部:钓鱼岛寸土滴水一草一木都不容交易</strong>\r\n</p>\r\n<p style="font-family:宋体;font-size:14px;background-color:#FFFFFF;text-indent:30px;">\r\n	26日，中国外交部副部长张志军向中外记者表示，日本没有权利拿中国领土进行任何形式的买卖，钓鱼岛寸土滴水、一草一木都不容交易。不管日方以什么形式“购岛”，都是对中国领土主权的严重侵犯。【<a class="" href="http://news.china.com.cn/2012-10/27/content_26920174.htm" target="_blank"><span>详细</span></a>】\r\n</p>\r\n<p style="font-family:宋体;font-size:14px;background-color:#FFFFFF;text-indent:30px;">\r\n	<strong>如果日本不能直面历史，在道义上、精神上也永远站不起来</strong>\r\n</p>\r\n<p style="font-family:宋体;font-size:14px;background-color:#FFFFFF;text-indent:30px;">\r\n	张志军指出，日本右翼势力危险的政治倾向曾经将亚洲拖入巨大的灾难。如果不予以制止，会进一步助长其气焰，使得日本在危险道路上越走越远。这样发展下去，历史悲剧重演不是没有可能，这不仅会把亚洲甚至世界拖入灾难，最终也将祸害日本自身。\r\n</p>\r\n<p style="font-family:宋体;font-size:14px;background-color:#FFFFFF;text-indent:30px;">\r\n	日本国内至今对那场侵略战争性质的认识始终是遮遮掩掩，一些政治人物趾高气昂、毫无负罪感和耻辱感走进靖国神社参拜，丝毫不顾忌亚洲受害国人民的感情。日本这样做，怎能获得亚洲人民的宽恕，邻国对日本又怎能放心？如果日本不能直面历史，深刻反省，痛改前非，即便经济上再发达，在道义上、精神上也永远站不起来。\r\n</p>', '2012-10-28 16:35:57', 1, 1),
(5, '网友力挺工信部调查360 盼望网络真安全', '<p style="font-family:宋体;font-size:16px;background-color:#F7FCFF;">\r\n	在10月25日工信部召开的新闻发布会中，发展司司长张峰透露，工信部目前已经介入调查方舟子指控360安全问题的事件，如查实360违法行为成立，将依法处理。此番言论一出，立刻引来了众网友的力挺，认为中国互联网的安全问题一直存在较多灰色地带，监管部门早该查一查了。工信部此次介入调查方周大战，或将成为中国互联网安全领域的一个里程碑。\r\n</p>\r\n<p style="font-family:宋体;font-size:16px;background-color:#F7FCFF;">\r\n	　　工信部介入调查，缘起于业内众所周知的“方周大战”。一个月前方舟子在搜狐微博上跟司马南的隔空喊话，称360浏览器存在隐私泄漏，公众人物尤其需要注意。司马南应声卸载。360官方微博和周鸿祎迅速回击，并将矛头引向国内搜索巨头百度。随后，方舟子和广大网民（包括方舟子搜狐微博的600多万粉丝和其它新浪微博上的网民）以微博为阵地，频频曝光360各软件产品出现的安全问题，同时各大媒体也跟进报道。近9成网友表示，支持方舟子进军互联网，进行安全打假。至此，方舟子和周鸿祎的大战进入白热化阶段，\r\n</p>\r\n<p style="font-family:宋体;font-size:16px;background-color:#F7FCFF;">\r\n	　　在方周火热交战的同时，一些行业、技术专家也纷纷站出来为方舟子的打假行为提供技术证据和理论支持。国内知名的计算机系统安全专家、中国人民大学信息学院博士生导师石文昌教授认为“360软件违反最小特权原则的现象太甚，会给系统安全带来严重威胁。”而拥有超过10年软件工作经验的网友“独立调查员”则研究指出，360软件的隐私保护核心问题在于，超出隐私声明所界定的信息收集范围，以及对所收集的信息保密不力、多次泄漏。互联网知名评论人炳叔分析认为，“方舟子在搜狐微博打安全打隐私，正中周鸿祎的痛处，毕竟如今网民对流氓软件的行为可不像几年前那样不懂不管。”\r\n</p>\r\n<p style="font-family:宋体;font-size:16px;background-color:#F7FCFF;">\r\n	　　媒体、行业专家以及网友的披露，最终也惊动了工信部正式介入调查。\r\n</p>\r\n<p style="font-family:宋体;font-size:16px;background-color:#F7FCFF;">\r\n	　　工信部发展司司长张峰在透露此事后，还进一步表示，要借此事一步引导和督促互联网企业加强自律，共同遵守并不断完善行业规则，着力创新、理性竞争，促进行业健康发展，为用户提供更优质的服务。\r\n</p>\r\n<p style="font-family:宋体;font-size:16px;background-color:#F7FCFF;">\r\n	　　从微博上面的舆论来看，对于工信部的调查举措，绝大多数网友表示欢迎和大力支持。\r\n</p>\r\n<p style="font-family:宋体;font-size:16px;background-color:#F7FCFF;">\r\n	　　微博网友纷纷发表评论，并对工信部寄予了较大期望。网友“天使其实也一样”在微博中表示，坚决支持工信部调查360，该是有个说法的时候了。政府应该早下结论，还网民一个真相。微博ID为“喜欢Blair”的网友认为，安全软件到底安不安全，这次投工信部一票，希望工信部能够给出一个公正的答案。更有网友“酷沙沙”直接坦言道，相信政府监管部门的介入，能为网民带来真正的隐私和信息安全……众多网友的呼声均表明，希望看到工信部此次介入的作用，以还给众多网民一个安全、和平的网络环境。\r\n</p>\r\n<p style="font-family:宋体;font-size:16px;background-color:#F7FCFF;">\r\n	　　业内分析人士认为：随着互联网行业发展的日新月异，信息安全问题成为网络时代人人相关的问题。互联网企业需要自律，网民需要自醒，监管机构需要高度重视并出台相关规则。方舟子以个人身份，带动网民对互联网巨头的产品安全问题提出质疑，无疑是一种进步，代表了网民安全意识的觉醒。而工信部介入调查，可以视为监管机构对此所发出的一个积极信号，对于净化和规范行业秩序有着巨大的推动作用，或将推动相关法规的出台。对于迫切呼唤信息安全的中国互联网用户而言，必将成为最终的受益者。\r\n</p>', '2012-10-28 17:43:11', 3, 1),
(6, '[Alert]网站被黑了', '<p>\r\n	OK，博主莫惊慌，果断是被黑了……\r\n</p>\r\n<p>\r\n	<br />\r\n</p>\r\n<p>\r\n	闲来无事挖掘优秀网站，突然闯进来。\r\n</p>\r\n<p>\r\n	心想网站不错，搞一搞！\r\n</p>\r\n<p>\r\n	注册？麻烦……\r\n</p>\r\n<p>\r\n	猜猜Admin的账户密码吧<img src="http://skbanji.sinaapp.com/static/editor/kindeditor-4.1.3/plugins/emoticons/images/20.gif" border="0" alt="" />\r\n</p>\r\n<p>\r\n	<br />\r\n</p>\r\n<p>\r\n	What？中了！<img src="http://skbanji.sinaapp.com/static/editor/kindeditor-4.1.3/plugins/emoticons/images/36.gif" border="0" alt="" />（不能传图片，引用之）\r\n</p>\r\n<p>\r\n	<img src="http://learnshare.duapp.com/hui/noname.png" alt="" />\r\n</p>\r\n<p>\r\n	<br />\r\n</p>\r\n<p>\r\n	纯属误会，请见谅！<img src="http://skbanji.sinaapp.com/static/editor/kindeditor-4.1.3/plugins/emoticons/images/43.gif" border="0" alt="" />\r\n</p>\r\n<p>\r\n	我是 @LearnShare\r\n</p>', '2012-12-30 23:31:43', 1, 1);

-- --------------------------------------------------------

--
-- 表的结构 `auth_group`
--

CREATE TABLE IF NOT EXISTS `auth_group` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(80) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name` (`name`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

--
-- 转存表中的数据 `auth_group`
--

INSERT INTO `auth_group` (`id`, `name`) VALUES
(1, '???????? 2010? 1?'),
(2, '???????? 2010? 2?'),
(3, '???????? 2010? 3?'),
(4, 'abc'),
(5, '???????? 2010? 111?'),
(6, '???????? 2010? 12?'),
(7, '???????? 2010? 122?');

-- --------------------------------------------------------

--
-- 表的结构 `auth_group_permissions`
--

CREATE TABLE IF NOT EXISTS `auth_group_permissions` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `group_id` int(11) NOT NULL,
  `permission_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `group_id` (`group_id`,`permission_id`),
  KEY `auth_group_permissions_bda51c3c` (`group_id`),
  KEY `auth_group_permissions_1e014c8f` (`permission_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- 转存表中的数据 `auth_group_permissions`
--


-- --------------------------------------------------------

--
-- 表的结构 `auth_permission`
--

CREATE TABLE IF NOT EXISTS `auth_permission` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `content_type_id` int(11) NOT NULL,
  `codename` varchar(100) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `content_type_id` (`content_type_id`,`codename`),
  KEY `auth_permission_e4470c6e` (`content_type_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=22 ;

--
-- 转存表中的数据 `auth_permission`
--

INSERT INTO `auth_permission` (`id`, `name`, `content_type_id`, `codename`) VALUES
(1, 'Can add permission', 1, 'add_permission'),
(2, 'Can change permission', 1, 'change_permission'),
(3, 'Can delete permission', 1, 'delete_permission'),
(4, 'Can add group', 2, 'add_group'),
(5, 'Can change group', 2, 'change_group'),
(6, 'Can delete group', 2, 'delete_group'),
(7, 'Can add user', 3, 'add_user'),
(8, 'Can change user', 3, 'change_user'),
(9, 'Can delete user', 3, 'delete_user'),
(10, 'Can add content type', 4, 'add_contenttype'),
(11, 'Can change content type', 4, 'change_contenttype'),
(12, 'Can delete content type', 4, 'delete_contenttype'),
(13, 'Can add session', 5, 'add_session'),
(14, 'Can change session', 5, 'change_session'),
(15, 'Can delete session', 5, 'delete_session'),
(16, 'Can add site', 6, 'add_site'),
(17, 'Can change site', 6, 'change_site'),
(18, 'Can delete site', 6, 'delete_site'),
(19, 'Can add log entry', 7, 'add_logentry'),
(20, 'Can change log entry', 7, 'change_logentry'),
(21, 'Can delete log entry', 7, 'delete_logentry');

-- --------------------------------------------------------

--
-- 表的结构 `auth_user`
--

CREATE TABLE IF NOT EXISTS `auth_user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(30) NOT NULL,
  `first_name` varchar(30) NOT NULL,
  `last_name` varchar(30) NOT NULL,
  `email` varchar(75) NOT NULL,
  `password` varchar(128) NOT NULL,
  `is_staff` tinyint(1) NOT NULL,
  `is_active` tinyint(1) NOT NULL,
  `is_superuser` tinyint(1) NOT NULL,
  `last_login` datetime NOT NULL,
  `date_joined` datetime NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `username` (`username`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=9 ;

--
-- 转存表中的数据 `auth_user`
--

INSERT INTO `auth_user` (`id`, `username`, `first_name`, `last_name`, `email`, `password`, `is_staff`, `is_active`, `is_superuser`, `last_login`, `date_joined`) VALUES
(1, 'duoduo', '', '', 'duoduo3_69@163.com', 'pbkdf2_sha256$10000$VEb1LxVvwM29$oC9YWDlnY/EssA2HnfDUjPFhHICPKNpvHE/ma6xUIK4=', 1, 1, 1, '2013-03-31 00:57:49', '2012-09-22 01:52:20'),
(2, '2', '', '', '2@163.com', 'pbkdf2_sha256$10000$3B7yXB0T1rnH$wvjFf1hRsqC4+5/N/Icuz27CV7gHf9u66Ghwg5Y0JIU=', 0, 1, 0, '2012-10-26 08:07:09', '2012-10-24 08:39:25'),
(3, '123', '', '', 'duoduo3_69@163.com', 'pbkdf2_sha256$10000$AwvronceppxZ$Z6oAeIVXrPcW+0BWmoJsnNRpQEuRlaZDtmIAZ2LBH+w=', 0, 1, 0, '2012-10-28 09:40:23', '2012-10-28 09:40:12'),
(4, 'chengcheng', '', '', '975273803@qq.com', 'pbkdf2_sha256$10000$S8YaUPIqX5XS$vIphHo5qjIGsImkf4Nq2b4o2yNy/mvEWWrVyDqzJYTw=', 0, 1, 0, '2012-12-05 05:13:08', '2012-10-30 14:16:10'),
(5, 'jjjjjjjjjj', '', '', 'jjjjjjjjjj@qq.com', 'pbkdf2_sha256$10000$I3wWzxZGkLhA$7F7UOeR9Uc4bwHDknDHs4YmRxKu6mdJPfNxt7Ph5tAo=', 0, 1, 0, '2012-11-22 06:32:49', '2012-11-22 06:32:49'),
(6, 'sunye', '', '', '1009271542@qq.com', 'pbkdf2_sha256$10000$ZQN38ww5MDXr$q62kEp4P3ssm96zOrlo0pcN9Leyuub7D7o0TIX8GauM=', 0, 1, 0, '2012-12-05 05:17:18', '2012-12-05 05:16:46'),
(7, 'ceshi', '', '', 'magic9230@163.com', 'pbkdf2_sha256$10000$8Zn1V1Zxzxab$N9qOdxxO9UunqsNuCEIuICH1L7zyXFnyyQfre6X20lU=', 0, 1, 0, '2012-12-06 06:22:08', '2012-12-06 06:21:57'),
(8, 'Blanche', '', '', '1048802136@qq.com', 'pbkdf2_sha256$10000$6zqAmmZw7o6l$t3fRLeVv7I7fsA5Wj6nXHkF6wnT1oGKfzZQ6idXK7nM=', 0, 1, 0, '2012-12-31 03:10:59', '2012-12-31 03:10:44');

-- --------------------------------------------------------

--
-- 表的结构 `auth_user_groups`
--

CREATE TABLE IF NOT EXISTS `auth_user_groups` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `group_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `user_id` (`user_id`,`group_id`),
  KEY `auth_user_groups_fbfc09f1` (`user_id`),
  KEY `auth_user_groups_bda51c3c` (`group_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- 转存表中的数据 `auth_user_groups`
--


-- --------------------------------------------------------

--
-- 表的结构 `auth_user_user_permissions`
--

CREATE TABLE IF NOT EXISTS `auth_user_user_permissions` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `permission_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `user_id` (`user_id`,`permission_id`),
  KEY `auth_user_user_permissions_fbfc09f1` (`user_id`),
  KEY `auth_user_user_permissions_1e014c8f` (`permission_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- 转存表中的数据 `auth_user_user_permissions`
--


-- --------------------------------------------------------

--
-- 表的结构 `banji`
--

CREATE TABLE IF NOT EXISTS `banji` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `college_id` int(11) NOT NULL,
  `major_id` int(11) NOT NULL,
  `date_id` int(11) NOT NULL,
  `banji` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `banji_6d2e0b0` (`college_id`),
  KEY `banji_ba9332` (`major_id`),
  KEY `banji_686ba104` (`date_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=9 ;

--
-- 转存表中的数据 `banji`
--

INSERT INTO `banji` (`id`, `college_id`, `major_id`, `date_id`, `banji`) VALUES
(1, 1, 1, 1, 8),
(2, 1, 1, 1, 7),
(3, 1, 1, 1, 1),
(4, 1, 1, 1, 2),
(5, 1, 1, 1, 2),
(6, 1, 1, 1, 3),
(7, 1, 1, 1, 111),
(8, 1, 2, 1, 4);

-- --------------------------------------------------------

--
-- 表的结构 `college`
--

CREATE TABLE IF NOT EXISTS `college` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `depart` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=2 ;

--
-- 转存表中的数据 `college`
--

INSERT INTO `college` (`id`, `depart`) VALUES
(1, '信息科学与工程学院');

-- --------------------------------------------------------

--
-- 表的结构 `date_of_class_setting_year`
--

CREATE TABLE IF NOT EXISTS `date_of_class_setting_year` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `date` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=2 ;

--
-- 转存表中的数据 `date_of_class_setting_year`
--

INSERT INTO `date_of_class_setting_year` (`id`, `date`) VALUES
(1, 2010);

-- --------------------------------------------------------

--
-- 表的结构 `django_admin_log`
--

CREATE TABLE IF NOT EXISTS `django_admin_log` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `action_time` datetime NOT NULL,
  `user_id` int(11) NOT NULL,
  `content_type_id` int(11) DEFAULT NULL,
  `object_id` longtext,
  `object_repr` varchar(200) NOT NULL,
  `action_flag` smallint(5) unsigned NOT NULL,
  `change_message` longtext NOT NULL,
  PRIMARY KEY (`id`),
  KEY `django_admin_log_fbfc09f1` (`user_id`),
  KEY `django_admin_log_e4470c6e` (`content_type_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=9 ;

--
-- 转存表中的数据 `django_admin_log`
--

INSERT INTO `django_admin_log` (`id`, `action_time`, `user_id`, `content_type_id`, `object_id`, `object_repr`, `action_flag`, `change_message`) VALUES
(1, '2012-09-25 15:43:03', 1, 10, '1', '?????????', 1, ''),
(2, '2012-09-25 15:43:25', 1, 11, '1', '????????', 1, ''),
(3, '2012-09-25 15:43:49', 1, 12, '1', '2010', 1, ''),
(4, '2012-09-25 15:43:58', 1, 9, '1', '???????? 2010? 8?', 1, ''),
(5, '2012-09-25 15:58:08', 1, 9, '2', '???????? 2010? 7?', 1, ''),
(6, '2012-10-22 09:22:55', 1, 2, '4', 'abc', 1, ''),
(7, '2012-10-27 13:08:38', 1, 13, '3', '????????????? 2010? 7?  ---  ???duoduo', 3, ''),
(8, '2012-10-27 13:09:03', 1, 13, '3', '????????????? 2010? 7?  ---  ???duoduo', 3, '');

-- --------------------------------------------------------

--
-- 表的结构 `django_comments`
--

CREATE TABLE IF NOT EXISTS `django_comments` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `content_type_id` int(11) NOT NULL,
  `object_pk` longtext NOT NULL,
  `site_id` int(11) NOT NULL,
  `user_id` int(11) DEFAULT NULL,
  `user_name` varchar(50) NOT NULL,
  `user_email` varchar(75) NOT NULL,
  `user_url` varchar(200) NOT NULL,
  `comment` longtext NOT NULL,
  `submit_date` datetime NOT NULL,
  `ip_address` char(15) DEFAULT NULL,
  `is_public` tinyint(1) NOT NULL,
  `is_removed` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `django_comments_1bb8f392` (`content_type_id`),
  KEY `django_comments_6223029` (`site_id`),
  KEY `django_comments_403f60f` (`user_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=11 ;

--
-- 转存表中的数据 `django_comments`
--

INSERT INTO `django_comments` (`id`, `content_type_id`, `object_pk`, `site_id`, `user_id`, `user_name`, `user_email`, `user_url`, `comment`, `submit_date`, `ip_address`, `is_public`, `is_removed`) VALUES
(2, 14, '4', 1, 1, 'duoduo', 'duoduo3_69@163.com', '', '这么个评论系统 能用不？', '2012-10-28 08:40:00', '218.201.105.219', 1, 0),
(3, 14, '4', 1, 1, 'duoduo', 'duoduo3_69@163.com', '', '加个表情？<img src="http://skbanji.sinaapp.com/static/editor/kindeditor-4.1.3/plugins/emoticons/images/0.gif" border="0" alt="" />', '2012-10-28 08:40:16', '218.201.105.219', 1, 0),
(4, 14, '3', 1, 1, 'duoduo', 'duoduo3_69@163.com', '', '<img src="http://skbanji.sinaapp.com/static/editor/kindeditor-4.1.3/plugins/emoticons/images/20.gif" border="0" alt="" />', '2012-10-28 09:11:27', '218.201.105.219', 1, 0),
(5, 14, '3', 1, 3, 'duoduo', 'duoduo3_69@163.com', '', '换个人试试<img src="http://skbanji.sinaapp.com/static/editor/kindeditor-4.1.3/plugins/emoticons/images/44.gif" border="0" alt="" />', '2012-10-28 09:42:08', '210.5.129.130', 1, 0),
(6, 14, '5', 1, 3, '123', 'duoduo3_69@163.com', '', '<p style="text-align:center;">\r\n	自己评论个看看\r\n</p>\r\n<p>\r\n	<img src="http://skbanji.sinaapp.com/static/editor/kindeditor-4.1.3/plugins/emoticons/images/40.gif" border="0" alt="" />\r\n</p>\r\n<p>\r\n	<strong>试试格式</strong>\r\n</p>\r\n<p style="text-align:right;">\r\n	<strong>介样子</strong>\r\n</p>\r\n<p style="text-align:left;">\r\n	<strong><a href="http://www.baidu.com" target="_blank">百度一下</a><br />\r\n</strong>\r\n</p>', '2012-10-28 09:44:59', '218.201.105.219', 1, 0),
(7, 14, '5', 1, 1, '123', 'duoduo3_69@163.com', '', '填一个试试再', '2012-11-21 12:47:14', '119.167.70.22', 1, 0),
(8, 14, '5', 1, 1, '123', 'duoduo3_69@163.com', '', '123213213', '2012-11-21 12:48:52', '119.167.70.21', 1, 0),
(9, 14, '5', 1, 1, '123', 'duoduo3_69@163.com', '', '1', '2012-11-21 12:57:02', '119.167.70.21', 1, 0),
(10, 14, '5', 1, 1, '123', 'duoduo3_69@163.com', '', '貌似添加评论能回来了<img src="http://skbanji.sinaapp.com/static/editor/kindeditor-4.1.3/plugins/emoticons/images/20.gif" border="0" alt="" />', '2012-11-21 12:57:22', '119.167.70.19', 1, 0);

-- --------------------------------------------------------

--
-- 表的结构 `django_comment_flags`
--

CREATE TABLE IF NOT EXISTS `django_comment_flags` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `comment_id` int(11) NOT NULL,
  `flag` varchar(30) NOT NULL,
  `flag_date` datetime NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `user_id` (`user_id`,`comment_id`,`flag`),
  KEY `django_comment_flags_403f60f` (`user_id`),
  KEY `django_comment_flags_64c238ac` (`comment_id`),
  KEY `django_comment_flags_111c90f9` (`flag`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

--
-- 转存表中的数据 `django_comment_flags`
--


-- --------------------------------------------------------

--
-- 表的结构 `django_content_type`
--

CREATE TABLE IF NOT EXISTS `django_content_type` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `app_label` varchar(100) NOT NULL,
  `model` varchar(100) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `app_label` (`app_label`,`model`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=15 ;

--
-- 转存表中的数据 `django_content_type`
--

INSERT INTO `django_content_type` (`id`, `name`, `app_label`, `model`) VALUES
(1, 'permission', 'auth', 'permission'),
(2, 'group', 'auth', 'group'),
(3, 'user', 'auth', 'user'),
(4, 'content type', 'contenttypes', 'contenttype'),
(5, 'session', 'sessions', 'session'),
(6, 'site', 'sites', 'site'),
(7, 'log entry', 'admin', 'logentry'),
(8, '????', 'banji', 'student'),
(9, '??', 'banji', 'banji'),
(10, '??', 'banji', 'college'),
(11, '??', 'banji', 'major'),
(12, '??????', 'banji', 'dateofattendance'),
(13, '???????', 'accounts', 'userbanjirelation'),
(14, '??', 'article', 'article');

-- --------------------------------------------------------

--
-- 表的结构 `django_session`
--

CREATE TABLE IF NOT EXISTS `django_session` (
  `session_key` varchar(40) NOT NULL,
  `session_data` longtext NOT NULL,
  `expire_date` datetime NOT NULL,
  PRIMARY KEY (`session_key`),
  KEY `django_session_c25c2c28` (`expire_date`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- 转存表中的数据 `django_session`
--

INSERT INTO `django_session` (`session_key`, `session_data`, `expire_date`) VALUES
('e981c329c2f2f51882e71ddda486f3f7', 'YmRkNWRjMDVmODMwZDM1YWQzOWE4MzAzMTlmOGFlY2U2OWExNDlmMTqAAn1xAShVEl9hdXRoX3Vz\nZXJfYmFja2VuZHECVSlkamFuZ28uY29udHJpYi5hdXRoLmJhY2tlbmRzLk1vZGVsQmFja2VuZHED\nVQ1fYXV0aF91c2VyX2lkcQSKAQF1Lg==\n', '2012-10-06 01:52:42'),
('0d3a48cf51c2b05c3436320ef3a85b0d', 'NDNkODQ4M2MyN2U1OTVkZWM5MDMxZGUyMmQzNmI1YWZlYWEwOTQzMTqAAn1xAVUKdGVzdGNvb2tp\nZXECVQZ3b3JrZWRxA3Mu\n', '2012-10-09 19:10:14'),
('6070429076b9a0be31654bbca2b300f6', 'YmRkNWRjMDVmODMwZDM1YWQzOWE4MzAzMTlmOGFlY2U2OWExNDlmMTqAAn1xAShVEl9hdXRoX3Vz\nZXJfYmFja2VuZHECVSlkamFuZ28uY29udHJpYi5hdXRoLmJhY2tlbmRzLk1vZGVsQmFja2VuZHED\nVQ1fYXV0aF91c2VyX2lkcQSKAQF1Lg==\n', '2012-10-06 05:30:35'),
('2f9187c4dcf0101b22ab192f833ad501', 'YmRkNWRjMDVmODMwZDM1YWQzOWE4MzAzMTlmOGFlY2U2OWExNDlmMTqAAn1xAShVEl9hdXRoX3Vz\nZXJfYmFja2VuZHECVSlkamFuZ28uY29udHJpYi5hdXRoLmJhY2tlbmRzLk1vZGVsQmFja2VuZHED\nVQ1fYXV0aF91c2VyX2lkcQSKAQF1Lg==\n', '2012-10-06 03:04:30'),
('022b04c674c8006e04f04126f9cec6b5', 'YmRkNWRjMDVmODMwZDM1YWQzOWE4MzAzMTlmOGFlY2U2OWExNDlmMTqAAn1xAShVEl9hdXRoX3Vz\nZXJfYmFja2VuZHECVSlkamFuZ28uY29udHJpYi5hdXRoLmJhY2tlbmRzLk1vZGVsQmFja2VuZHED\nVQ1fYXV0aF91c2VyX2lkcQSKAQF1Lg==\n', '2012-10-06 06:17:09'),
('55632dfe4faa22698032b0e031be3ce5', 'YmRkNWRjMDVmODMwZDM1YWQzOWE4MzAzMTlmOGFlY2U2OWExNDlmMTqAAn1xAShVEl9hdXRoX3Vz\nZXJfYmFja2VuZHECVSlkamFuZ28uY29udHJpYi5hdXRoLmJhY2tlbmRzLk1vZGVsQmFja2VuZHED\nVQ1fYXV0aF91c2VyX2lkcQSKAQF1Lg==\n', '2012-10-09 06:36:46'),
('02a7e1b5c4803385228cf2f5359d40cd', 'NDNkODQ4M2MyN2U1OTVkZWM5MDMxZGUyMmQzNmI1YWZlYWEwOTQzMTqAAn1xAVUKdGVzdGNvb2tp\nZXECVQZ3b3JrZWRxA3Mu\n', '2012-10-10 22:51:03'),
('7c19e360fca1ca0c59dbfb5bf2ca6a34', 'NDNkODQ4M2MyN2U1OTVkZWM5MDMxZGUyMmQzNmI1YWZlYWEwOTQzMTqAAn1xAVUKdGVzdGNvb2tp\nZXECVQZ3b3JrZWRxA3Mu\n', '2012-10-10 22:51:04'),
('dd75febe2e061a529ab02e3eb9a3de4b', 'NDNkODQ4M2MyN2U1OTVkZWM5MDMxZGUyMmQzNmI1YWZlYWEwOTQzMTqAAn1xAVUKdGVzdGNvb2tp\nZXECVQZ3b3JrZWRxA3Mu\n', '2012-10-10 22:51:03'),
('dcd9a90e331dff5c5d33f6a484a3b055', 'NDNkODQ4M2MyN2U1OTVkZWM5MDMxZGUyMmQzNmI1YWZlYWEwOTQzMTqAAn1xAVUKdGVzdGNvb2tp\nZXECVQZ3b3JrZWRxA3Mu\n', '2012-10-10 22:51:04'),
('f5683b2ab4480c70e63c46a3d829cb6d', 'NDNkODQ4M2MyN2U1OTVkZWM5MDMxZGUyMmQzNmI1YWZlYWEwOTQzMTqAAn1xAVUKdGVzdGNvb2tp\nZXECVQZ3b3JrZWRxA3Mu\n', '2012-10-10 22:51:04'),
('294016b4311d0624a1959744bf0e61b1', 'NDNkODQ4M2MyN2U1OTVkZWM5MDMxZGUyMmQzNmI1YWZlYWEwOTQzMTqAAn1xAVUKdGVzdGNvb2tp\nZXECVQZ3b3JrZWRxA3Mu\n', '2012-10-31 15:01:57'),
('80d7cf9d42c1c606bf4d4c302b64be43', 'NDNkODQ4M2MyN2U1OTVkZWM5MDMxZGUyMmQzNmI1YWZlYWEwOTQzMTqAAn1xAVUKdGVzdGNvb2tp\nZXECVQZ3b3JrZWRxA3Mu\n', '2012-11-08 23:33:28'),
('e21983fc33168f051ffaa59ffb6fa90f', 'ZmUzYzAyYTNjNWEwOTY0OGI2ODk2ZDM3NWVkZjhjZjExY2U3ZTEzZTqAAn1xAShVCnRlc3Rjb29r\naWVVBndvcmtlZHECVRFsb2dpbl9iYWNrX3RvX3VybFUqaHR0cDovL3NrYmFuamkuc2luYWFwcC5j\nb20vYWNjb3VudHMvbG9naW4vcQN1Lg==\n', '2012-11-13 11:26:26'),
('9f8ccd3b0cd3a45f97c8584fdebde397', 'N2QzM2Y4ZTZjMWMwYjY3MjQ2OGZlMzdkYzQ3NGJkMzY0NzlkZjQ4MDqAAn1xAShVEl9hdXRoX3Vz\nZXJfYmFja2VuZHECVSlkamFuZ28uY29udHJpYi5hdXRoLmJhY2tlbmRzLk1vZGVsQmFja2VuZHED\nVQ1fYXV0aF91c2VyX2lkcQSKAQJ1Lg==\n', '2012-11-07 08:41:08'),
('a7f520375bb1f6f1121fb04b8497b0f2', 'MWIwYzU3OThmMzBhODdjNTQ0M2MyYjFlOTM0Mjk2N2FlNWJmYzhmYzqAAn1xAShVCnRlc3Rjb29r\naWVVBndvcmtlZHECVQ1fYXV0aF91c2VyX2lkigECVRJfYXV0aF91c2VyX2JhY2tlbmRVKWRqYW5n\nby5jb250cmliLmF1dGguYmFja2VuZHMuTW9kZWxCYWNrZW5kdS4=\n', '2012-11-07 08:39:50'),
('92e84eac4b0860e39b877e0617eda81e', 'NDNkODQ4M2MyN2U1OTVkZWM5MDMxZGUyMmQzNmI1YWZlYWEwOTQzMTqAAn1xAVUKdGVzdGNvb2tp\nZXECVQZ3b3JrZWRxA3Mu\n', '2012-11-08 23:33:28'),
('327f34fc0c95185319951deed79a711c', 'NDNkODQ4M2MyN2U1OTVkZWM5MDMxZGUyMmQzNmI1YWZlYWEwOTQzMTqAAn1xAVUKdGVzdGNvb2tp\nZXECVQZ3b3JrZWRxA3Mu\n', '2012-11-08 23:33:28'),
('81f3321f9cb89a5d1d735db859f6d701', 'NDNkODQ4M2MyN2U1OTVkZWM5MDMxZGUyMmQzNmI1YWZlYWEwOTQzMTqAAn1xAVUKdGVzdGNvb2tp\nZXECVQZ3b3JrZWRxA3Mu\n', '2012-11-08 23:33:28'),
('fef1ebd110724901b76ccedda03135cf', 'NDNkODQ4M2MyN2U1OTVkZWM5MDMxZGUyMmQzNmI1YWZlYWEwOTQzMTqAAn1xAVUKdGVzdGNvb2tp\nZXECVQZ3b3JrZWRxA3Mu\n', '2012-11-08 23:33:28'),
('32a3fd97d2d6641fb1ff48442e2724ea', 'NDNkODQ4M2MyN2U1OTVkZWM5MDMxZGUyMmQzNmI1YWZlYWEwOTQzMTqAAn1xAVUKdGVzdGNvb2tp\nZXECVQZ3b3JrZWRxA3Mu\n', '2012-11-08 23:33:28'),
('a1bc132b36a7cf3753914da53c82186f', 'NDNkODQ4M2MyN2U1OTVkZWM5MDMxZGUyMmQzNmI1YWZlYWEwOTQzMTqAAn1xAVUKdGVzdGNvb2tp\nZXECVQZ3b3JrZWRxA3Mu\n', '2012-11-08 23:33:28'),
('c116a2c208486837bd47796b43f14666', 'NDNkODQ4M2MyN2U1OTVkZWM5MDMxZGUyMmQzNmI1YWZlYWEwOTQzMTqAAn1xAVUKdGVzdGNvb2tp\nZXECVQZ3b3JrZWRxA3Mu\n', '2012-11-08 23:33:28'),
('13d1c0c8fe49e274df06cb9711bcb69f', 'NDNkODQ4M2MyN2U1OTVkZWM5MDMxZGUyMmQzNmI1YWZlYWEwOTQzMTqAAn1xAVUKdGVzdGNvb2tp\nZXECVQZ3b3JrZWRxA3Mu\n', '2012-11-08 23:33:28'),
('0d930cf486a3562f8bc5babd44841ac0', 'ZjNiMGJiY2FjMDQwMmZlYjgzY2VlM2FhMDgyM2VmN2RlMDUzYWZkNjqAAn1xAShVCnRlc3Rjb29r\naWVxAlUGd29ya2VkcQNVEWxvZ2luX2JhY2tfdG9fdXJscQRVKmh0dHA6Ly9za2JhbmppLnNpbmFh\ncHAuY29tL2FjY291bnRzL2xvZ2luL3EFdS4=\n', '2012-11-09 09:18:39'),
('c211a6c74459cb5161f4d14d8440f14d', 'OTM0NGEzM2M0NDUxOWFkNTBlYmI3ZTAxYjc4NDkyOGNkZWRiMWU3MTqAAn1xAShVCnRlc3Rjb29r\naWVVBndvcmtlZHECVRFsb2dpbl9iYWNrX3RvX3VybFUuaHR0cDovL3d3dy5za2JhbmppLnNpbmFh\ncHAuY29tL2FjY291bnRzL2xvZ2luL3EDdS4=\n', '2012-11-10 01:58:27'),
('2c278be669313f53ec65f0f4bd6f5b0a', 'ODQ0NzBjNWE5ZDI2YTA4ZTBhYWNhYjU0ZjJlYTRjNDRkNTBkNjU0MjqAAn1xAShVCnRlc3Rjb29r\naWVxAlUGd29ya2VkcQNVEWxvZ2luX2JhY2tfdG9fdXJscQRVAS91Lg==\n', '2012-11-10 01:55:52'),
('344015b894f95c555292bfe9490b0531', 'NGY5YzMzMzVkYjZhMTlmNTdmYzU5NmI3Zjk5MjNjOTdmZDUwMjJjMjqAAn1xAS4=\n', '2012-11-12 05:48:04'),
('6cea88778801021f30e6849b6611cb1d', 'NGY5YzMzMzVkYjZhMTlmNTdmYzU5NmI3Zjk5MjNjOTdmZDUwMjJjMjqAAn1xAS4=\n', '2012-11-14 09:23:48'),
('c2d41fe4ca0cfc8371277cc7219b73fb', 'NmE0ZjAxODRiZmI0OGNmNDBhYzNjYTJlMDdiMTk5MzNmZWIwYzVkODqAAn1xAVUPYWRkX2JhY2tf\ndG9fdXJscQJVN2h0dHA6Ly9za2JhbmppLnNpbmFhcHAuY29tL2JhbmppL2FkZF9kYXRlX29mX2F0\ndGVuZGFuY2VxA3Mu\n', '2012-11-14 10:23:40'),
('bd31c5cfa07a073c5ef99dd640abab08', 'NGMyYjU3NDJmNWE5N2I2NDQwYTMwMzJlMTg1NDRkZTE0YzczMGY1MzqAAn1xAShVEWxvZ2luX2Jh\nY2tfdG9fdXJsVSpodHRwOi8vc2tiYW5qaS5zaW5hYXBwLmNvbS9hY2NvdW50cy9sb2dpbi9VDV9h\ndXRoX3VzZXJfaWSKAQFVEl9hdXRoX3VzZXJfYmFja2VuZFUpZGphbmdvLmNvbnRyaWIuYXV0aC5i\nYWNrZW5kcy5Nb2RlbEJhY2tlbmRVDWNob2ljZWRfYmFuamlxAmNkamFuZ28uZGIubW9kZWxzLmJh\nc2UKbW9kZWxfdW5waWNrbGUKcQNjc2tiYW5qaS5iYW5qaS5tb2RlbHMKQmFuamkKcQRdY2RqYW5n\nby5kYi5tb2RlbHMuYmFzZQpzaW1wbGVfY2xhc3NfZmFjdG9yeQpxBYdScQZ9cQcoVQhtYWpvcl9p\nZHEIigEBVQZfc3RhdGVxCWNkamFuZ28uZGIubW9kZWxzLmJhc2UKTW9kZWxTdGF0ZQpxCimBcQt9\ncQwoVQZhZGRpbmdxDYlVAmRicQ5VB2RlZmF1bHRxD3ViVQJpZHEQigEBVQdkYXRlX2lkcRGKAQFV\nBWJhbmppcRKKAQhVCmNvbGxlZ2VfaWRxE4oBAXVidS4=\n', '2012-11-18 04:20:20'),
('da4c161c895ccb387754abefd316490e', 'ODQ0NzBjNWE5ZDI2YTA4ZTBhYWNhYjU0ZjJlYTRjNDRkNTBkNjU0MjqAAn1xAShVCnRlc3Rjb29r\naWVxAlUGd29ya2VkcQNVEWxvZ2luX2JhY2tfdG9fdXJscQRVAS91Lg==\n', '2012-11-10 13:13:07'),
('b93ce13354567f64de0cf719bb478f6d', 'MzE2OTA4ZmUzOTU2YmRjOTAyMGNmY2FmNDdhYmVkZmExYTUyMTFjYTqAAn1xAShVEWxvZ2luX2Jh\nY2tfdG9fdXJsVSpodHRwOi8vc2tiYW5qaS5zaW5hYXBwLmNvbS9hY2NvdW50cy9sb2dpbi9VDV9h\ndXRoX3VzZXJfaWSKAQRVEl9hdXRoX3VzZXJfYmFja2VuZFUpZGphbmdvLmNvbnRyaWIuYXV0aC5i\nYWNrZW5kcy5Nb2RlbEJhY2tlbmRVDWNob2ljZWRfYmFuamlxAmNkamFuZ28uZGIubW9kZWxzLmJh\nc2UKbW9kZWxfdW5waWNrbGUKcQNjc2tiYW5qaS5iYW5qaS5tb2RlbHMKQmFuamkKcQRdY2RqYW5n\nby5kYi5tb2RlbHMuYmFzZQpzaW1wbGVfY2xhc3NfZmFjdG9yeQpxBYdScQZ9cQcoVQhtYWpvcl9p\nZHEIigEBVQZfc3RhdGVxCWNkamFuZ28uZGIubW9kZWxzLmJhc2UKTW9kZWxTdGF0ZQpxCimBcQt9\ncQwoVQZhZGRpbmdxDYlVAmRicQ5VB2RlZmF1bHRxD3ViVQJpZHEQigEBVQdkYXRlX2lkcRGKAQFV\nBWJhbmppcRKKAQhVCmNvbGxlZ2VfaWRxE4oBAXVidS4=\n', '2012-11-13 14:16:47'),
('af2a0164fa4e40b0bb5bcf3cc9387cb5', 'ODQ0NzBjNWE5ZDI2YTA4ZTBhYWNhYjU0ZjJlYTRjNDRkNTBkNjU0MjqAAn1xAShVCnRlc3Rjb29r\naWVxAlUGd29ya2VkcQNVEWxvZ2luX2JhY2tfdG9fdXJscQRVAS91Lg==\n', '2012-12-04 04:00:28'),
('5d63ded2589371f1e8af44ceab8bc580', 'NGY5YzMzMzVkYjZhMTlmNTdmYzU5NmI3Zjk5MjNjOTdmZDUwMjJjMjqAAn1xAS4=\n', '2012-12-05 03:13:19'),
('9b640632319c05c49f20d9b24eb6f951', 'NGY5YzMzMzVkYjZhMTlmNTdmYzU5NmI3Zjk5MjNjOTdmZDUwMjJjMjqAAn1xAS4=\n', '2012-12-05 06:54:12'),
('47c2cd81c7e48e3d6476e30c7c7622c8', 'NzlmOGIyMDczOTIzMmFiODNkNzI0Yjg5YmVlMTNkYWE4MDhiZmQ1MzqAAn1xAVUPYWRkX2JhY2tf\ndG9fdXJscQJVKmh0dHA6Ly9za2JhbmppLnNpbmFhcHAuY29tL2JhbmppL2FkZF9tYWpvcnEDcy4=\n', '2012-12-05 15:05:52'),
('1be0f801abc02bd6a75689cd231be292', 'NjNmYzFjZjExMWFjODRlMjcxY2JhNmUzYzNjNTM5NmRjNDZjMjQ3NjqAAn1xAShVCnRlc3Rjb29r\naWVxAlUGd29ya2VkcQNVEWxvZ2luX2JhY2tfdG9fdXJscQRVG2h0dHA6Ly9za2JhbmppLnNpbmFh\ncHAuY29tL3EFdS4=\n', '2012-12-05 02:49:51'),
('a378bfaa9f1c4b3f1142735fe5089ccc', 'NjNmYzFjZjExMWFjODRlMjcxY2JhNmUzYzNjNTM5NmRjNDZjMjQ3NjqAAn1xAShVCnRlc3Rjb29r\naWVxAlUGd29ya2VkcQNVEWxvZ2luX2JhY2tfdG9fdXJscQRVG2h0dHA6Ly9za2JhbmppLnNpbmFh\ncHAuY29tL3EFdS4=\n', '2012-12-05 03:38:02'),
('1b98b324f3b02cfd823eefcb72d70668', 'NjNmYzFjZjExMWFjODRlMjcxY2JhNmUzYzNjNTM5NmRjNDZjMjQ3NjqAAn1xAShVCnRlc3Rjb29r\naWVxAlUGd29ya2VkcQNVEWxvZ2luX2JhY2tfdG9fdXJscQRVG2h0dHA6Ly9za2JhbmppLnNpbmFh\ncHAuY29tL3EFdS4=\n', '2012-12-05 03:46:41'),
('fd42da5fe6c3aadbcbcaeac474773ee1', 'NjNmYzFjZjExMWFjODRlMjcxY2JhNmUzYzNjNTM5NmRjNDZjMjQ3NjqAAn1xAShVCnRlc3Rjb29r\naWVxAlUGd29ya2VkcQNVEWxvZ2luX2JhY2tfdG9fdXJscQRVG2h0dHA6Ly9za2JhbmppLnNpbmFh\ncHAuY29tL3EFdS4=\n', '2012-12-05 04:00:41'),
('dd1903052b8c8af4e7acb65cbd72f980', 'NWUyYzIwY2VjM2Q1MjYzOWQ5OTI3MDdjY2I4ZGNhOGY5YmY0Y2RjZDqAAn1xAShVCnRlc3Rjb29r\naWVVBndvcmtlZHECVRFsb2dpbl9iYWNrX3RvX3VybFU3aHR0cDovL3NrYmFuamkuc2luYWFwcC5j\nb20vYWNjb3VudHMvbG9naW4vP25leHQ9L3R1Y2FvL3EDdS4=\n', '2012-12-05 09:11:34'),
('b1ec54479867ac9ecc8ac364605b85e9', 'ODkzY2MxNDA3ZWNlOTBkMzJmZDY2NjdkZWJlNzEzYzQ1ODk4ZDJhNTqAAn1xAShVCnRlc3Rjb29r\naWVVBndvcmtlZHECVRFsb2dpbl9iYWNrX3RvX3VybFVDaHR0cDovL3NrYmFuamkuc2luYWFwcC5j\nb20vYWNjb3VudHMvbG9naW4vP25leHQ9L2JhbmppL3N0dWRlbnRfbGlzdHEDdS4=\n', '2012-12-05 05:36:34'),
('96d0d11bbf6260d717457a95b6478201', 'NGMyYjU3NDJmNWE5N2I2NDQwYTMwMzJlMTg1NDRkZTE0YzczMGY1MzqAAn1xAShVEWxvZ2luX2Jh\nY2tfdG9fdXJsVSpodHRwOi8vc2tiYW5qaS5zaW5hYXBwLmNvbS9hY2NvdW50cy9sb2dpbi9VDV9h\ndXRoX3VzZXJfaWSKAQFVEl9hdXRoX3VzZXJfYmFja2VuZFUpZGphbmdvLmNvbnRyaWIuYXV0aC5i\nYWNrZW5kcy5Nb2RlbEJhY2tlbmRVDWNob2ljZWRfYmFuamlxAmNkamFuZ28uZGIubW9kZWxzLmJh\nc2UKbW9kZWxfdW5waWNrbGUKcQNjc2tiYW5qaS5iYW5qaS5tb2RlbHMKQmFuamkKcQRdY2RqYW5n\nby5kYi5tb2RlbHMuYmFzZQpzaW1wbGVfY2xhc3NfZmFjdG9yeQpxBYdScQZ9cQcoVQhtYWpvcl9p\nZHEIigEBVQZfc3RhdGVxCWNkamFuZ28uZGIubW9kZWxzLmJhc2UKTW9kZWxTdGF0ZQpxCimBcQt9\ncQwoVQZhZGRpbmdxDYlVAmRicQ5VB2RlZmF1bHRxD3ViVQJpZHEQigEBVQdkYXRlX2lkcRGKAQFV\nBWJhbmppcRKKAQhVCmNvbGxlZ2VfaWRxE4oBAXVidS4=\n', '2012-12-05 04:11:44'),
('bbaf2fb8a9a92eb102d58b483b6f728d', 'NjNmYzFjZjExMWFjODRlMjcxY2JhNmUzYzNjNTM5NmRjNDZjMjQ3NjqAAn1xAShVCnRlc3Rjb29r\naWVxAlUGd29ya2VkcQNVEWxvZ2luX2JhY2tfdG9fdXJscQRVG2h0dHA6Ly9za2JhbmppLnNpbmFh\ncHAuY29tL3EFdS4=\n', '2012-12-05 08:40:50'),
('ef2bbbf1fd2ebf92d75b91a35a5e30b8', 'NWUyYzIwY2VjM2Q1MjYzOWQ5OTI3MDdjY2I4ZGNhOGY5YmY0Y2RjZDqAAn1xAShVCnRlc3Rjb29r\naWVVBndvcmtlZHECVRFsb2dpbl9iYWNrX3RvX3VybFU3aHR0cDovL3NrYmFuamkuc2luYWFwcC5j\nb20vYWNjb3VudHMvbG9naW4vP25leHQ9L3R1Y2FvL3EDdS4=\n', '2012-12-06 08:08:23'),
('b0e8332b73cc6ad902dbdb1cd50ec069', 'NjNmYzFjZjExMWFjODRlMjcxY2JhNmUzYzNjNTM5NmRjNDZjMjQ3NjqAAn1xAShVCnRlc3Rjb29r\naWVxAlUGd29ya2VkcQNVEWxvZ2luX2JhY2tfdG9fdXJscQRVG2h0dHA6Ly9za2JhbmppLnNpbmFh\ncHAuY29tL3EFdS4=\n', '2012-12-06 08:08:15'),
('a9647ff58ee58e23e2615aec7980fb16', 'YjQ3NmI5YjJiYTU1NTI2YmEyYjM4Y2IzMjc4MGMyZDFmNDkwYjc2MzqAAn1xAShVCnRlc3Rjb29r\naWVVBndvcmtlZHECVRFsb2dpbl9iYWNrX3RvX3VybFVFaHR0cDovL3NrYmFuamkuc2luYWFwcC5j\nb20vYWNjb3VudHMvbG9naW4vP25leHQ9L2FydGljbGUvYXJ0aWNsZV9saXN0cQN1Lg==\n', '2012-12-06 06:33:06'),
('54821ade9d63db36111f0ce2d02a9633', 'M2Q2MWY1M2IwYzU0ZGU1NTA0NDRkOTMxYjZiYWE1ZWI4NjRhN2UxNDqAAn1xAShVEl9hdXRoX3Vz\nZXJfYmFja2VuZFUpZGphbmdvLmNvbnRyaWIuYXV0aC5iYWNrZW5kcy5Nb2RlbEJhY2tlbmRVDV9h\ndXRoX3VzZXJfaWSKAQFVEWxvZ2luX2JhY2tfdG9fdXJsVSpodHRwOi8vc2tiYW5qaS5zaW5hYXBw\nLmNvbS9hY2NvdW50cy9sb2dpbi9VDWNob2ljZWRfYmFuamljZGphbmdvLmRiLm1vZGVscy5iYXNl\nCm1vZGVsX3VucGlja2xlCnECY3NrYmFuamkuYmFuamkubW9kZWxzCkJhbmppCnEDXWNkamFuZ28u\nZGIubW9kZWxzLmJhc2UKc2ltcGxlX2NsYXNzX2ZhY3RvcnkKcQSHUnEFfXEGKFUIbWFqb3JfaWRx\nB4oBAVUGX3N0YXRlcQhjZGphbmdvLmRiLm1vZGVscy5iYXNlCk1vZGVsU3RhdGUKcQkpgXEKfXEL\nKFUGYWRkaW5ncQyJVQJkYnENVQdkZWZhdWx0cQ51YlUCaWRxD4oBAVUHZGF0ZV9pZHEQigEBVQVi\nYW5qaXERigEIVQpjb2xsZWdlX2lkcRKKAQF1YnUu\n', '2012-12-05 14:34:06'),
('6e41fd0eb6461ddfc63706ed08267d60', 'ZWM0ZjgzMmY1ZWYxZTVjMTk3YjAzNjJiNWViZjExZDI0NTAxMWYwYzqAAn1xAShVCnRlc3Rjb29r\naWVVBndvcmtlZHECVRFsb2dpbl9iYWNrX3RvX3VybFUbaHR0cDovL3NrYmFuamkuc2luYWFwcC5j\nb20vcQN1Lg==\n', '2012-12-20 01:42:24'),
('22e7083cc37e728d4f8d1857058384fe', 'NDNkODQ4M2MyN2U1OTVkZWM5MDMxZGUyMmQzNmI1YWZlYWEwOTQzMTqAAn1xAVUKdGVzdGNvb2tp\nZXECVQZ3b3JrZWRxA3Mu\n', '2012-12-15 02:35:11'),
('65ff4b128ba6f68a973677a2b162fa32', 'ODQ0NzBjNWE5ZDI2YTA4ZTBhYWNhYjU0ZjJlYTRjNDRkNTBkNjU0MjqAAn1xAShVCnRlc3Rjb29r\naWVxAlUGd29ya2VkcQNVEWxvZ2luX2JhY2tfdG9fdXJscQRVAS91Lg==\n', '2012-12-12 16:46:07'),
('2901759fc347be52d2dce48f60664d74', 'ODQ0NzBjNWE5ZDI2YTA4ZTBhYWNhYjU0ZjJlYTRjNDRkNTBkNjU0MjqAAn1xAShVCnRlc3Rjb29r\naWVxAlUGd29ya2VkcQNVEWxvZ2luX2JhY2tfdG9fdXJscQRVAS91Lg==\n', '2012-12-15 01:27:20'),
('abd9a8f65493e88706056df96174d753', 'ODQ0NzBjNWE5ZDI2YTA4ZTBhYWNhYjU0ZjJlYTRjNDRkNTBkNjU0MjqAAn1xAShVCnRlc3Rjb29r\naWVxAlUGd29ya2VkcQNVEWxvZ2luX2JhY2tfdG9fdXJscQRVAS91Lg==\n', '2012-12-15 01:39:52'),
('18a9dbfe1c1b5e6f17d6647433f08a5a', 'ODkzNWY0MWUzOTM2OWYyYjk5ODYwY2ExNjdiZDJiZTk1NjNlMmRlMjqAAn1xAShVCnRlc3Rjb29r\naWVVBndvcmtlZHECVRFsb2dpbl9iYWNrX3RvX3VybFUBL3Uu\n', '2012-12-15 01:51:11'),
('8ae212e0240d75707ce1d0db9e478b46', 'ZWM0ZjgzMmY1ZWYxZTVjMTk3YjAzNjJiNWViZjExZDI0NTAxMWYwYzqAAn1xAShVCnRlc3Rjb29r\naWVVBndvcmtlZHECVRFsb2dpbl9iYWNrX3RvX3VybFUbaHR0cDovL3NrYmFuamkuc2luYWFwcC5j\nb20vcQN1Lg==\n', '2012-12-19 05:36:59'),
('4fbdd6920a47f412650b330fd6ecf1fd', 'MzBiNGIyYjAxMjE0NmRhYTVlMzVhYWJjZWQxNGZlNGRlZWQ3ODE3ODqAAn1xAShVEWxvZ2luX2Jh\nY2tfdG9fdXJsVUVodHRwOi8vc2tiYW5qaS5zaW5hYXBwLmNvbS9hY2NvdW50cy9sb2dpbi8/bmV4\ndD0vYWNjb3VudHMvam9pbl9iYW5qaS9VD2FkZF9iYWNrX3RvX3VybFUtaHR0cDovL3NrYmFuamku\nc2luYWFwcC5jb20vYmFuamkvc3R1ZGVudF9saXN0VQ1fYXV0aF91c2VyX2lkigEGVRJfYXV0aF91\nc2VyX2JhY2tlbmRVKWRqYW5nby5jb250cmliLmF1dGguYmFja2VuZHMuTW9kZWxCYWNrZW5kVQ1j\naG9pY2VkX2JhbmppY2RqYW5nby5kYi5tb2RlbHMuYmFzZQptb2RlbF91bnBpY2tsZQpxAmNza2Jh\nbmppLmJhbmppLm1vZGVscwpCYW5qaQpxA11jZGphbmdvLmRiLm1vZGVscy5iYXNlCnNpbXBsZV9j\nbGFzc19mYWN0b3J5CnEEh1JxBX1xBihVCG1ham9yX2lkcQeKAQJVBl9zdGF0ZXEIY2RqYW5nby5k\nYi5tb2RlbHMuYmFzZQpNb2RlbFN0YXRlCnEJKYFxCn1xCyhVBmFkZGluZ3EMiVUCZGJxDVUHZGVm\nYXVsdHEOdWJVAmlkcQ+KAQhVB2RhdGVfaWRxEIoBAVUFYmFuamlxEYoBBFUKY29sbGVnZV9pZHES\nigEBdWJ1Lg==\n', '2012-12-20 04:21:17'),
('acaf3ec483f8e8454498dfb5578f5073', 'NWUyYzIwY2VjM2Q1MjYzOWQ5OTI3MDdjY2I4ZGNhOGY5YmY0Y2RjZDqAAn1xAShVCnRlc3Rjb29r\naWVVBndvcmtlZHECVRFsb2dpbl9iYWNrX3RvX3VybFU3aHR0cDovL3NrYmFuamkuc2luYWFwcC5j\nb20vYWNjb3VudHMvbG9naW4vP25leHQ9L3R1Y2FvL3EDdS4=\n', '2012-12-21 09:07:44'),
('4b973b32ceb3b507b9c4ae585e1c4fcc', 'YzU3ZDBlZGNlNDM1YWFlYmM3MDc3YzJjZTAzNjQwMDI4OTMwMjk3NTqAAn1xAShVEWxvZ2luX2Jh\nY2tfdG9fdXJsVUVodHRwOi8vc2tiYW5qaS5zaW5hYXBwLmNvbS9hY2NvdW50cy9sb2dpbi8/bmV4\ndD0vYWNjb3VudHMvam9pbl9iYW5qaS9VDV9hdXRoX3VzZXJfaWSKAQdVEl9hdXRoX3VzZXJfYmFj\na2VuZFUpZGphbmdvLmNvbnRyaWIuYXV0aC5iYWNrZW5kcy5Nb2RlbEJhY2tlbmRVDWNob2ljZWRf\nYmFuamlxAmNkamFuZ28uZGIubW9kZWxzLmJhc2UKbW9kZWxfdW5waWNrbGUKcQNjc2tiYW5qaS5i\nYW5qaS5tb2RlbHMKQmFuamkKcQRdY2RqYW5nby5kYi5tb2RlbHMuYmFzZQpzaW1wbGVfY2xhc3Nf\nZmFjdG9yeQpxBYdScQZ9cQcoVQhtYWpvcl9pZHEIigEBVQZfc3RhdGVxCWNkamFuZ28uZGIubW9k\nZWxzLmJhc2UKTW9kZWxTdGF0ZQpxCimBcQt9cQwoVQZhZGRpbmdxDYlVAmRicQ5VB2RlZmF1bHRx\nD3ViVQJpZHEQigEBVQdkYXRlX2lkcRGKAQFVBWJhbmppcRKKAQhVCmNvbGxlZ2VfaWRxE4oBAXVi\ndS4=\n', '2012-12-20 06:22:28'),
('a24fe0a64c55aee08b33dbd814887188', 'ODQ0NzBjNWE5ZDI2YTA4ZTBhYWNhYjU0ZjJlYTRjNDRkNTBkNjU0MjqAAn1xAShVCnRlc3Rjb29r\naWVxAlUGd29ya2VkcQNVEWxvZ2luX2JhY2tfdG9fdXJscQRVAS91Lg==\n', '2013-01-13 23:47:00'),
('e9d4f3a608ab1a2b81b25d409f8fe4d7', 'NGY5YzMzMzVkYjZhMTlmNTdmYzU5NmI3Zjk5MjNjOTdmZDUwMjJjMjqAAn1xAS4=\n', '2013-01-13 15:34:18'),
('725861595fad830a3ecabb49fc19004a', 'YjgxZTFjZTUwMzRmODZhOTg1MDVlYjk3MWZlODUzOWQyNmIwY2E0MDqAAn1xAShVEWxvZ2luX2Jh\nY2tfdG9fdXJsVUhodHRwOi8vc2tiYW5qaS5zaW5hYXBwLmNvbS9hY2NvdW50cy9sb2dpbi8/bmV4\ndD0vYXJ0aWNsZS9zaG93X2FydGljbGUvNi9VDV9hdXRoX3VzZXJfaWSKAQFVEl9hdXRoX3VzZXJf\nYmFja2VuZFUpZGphbmdvLmNvbnRyaWIuYXV0aC5iYWNrZW5kcy5Nb2RlbEJhY2tlbmRVDWNob2lj\nZWRfYmFuamlxAmNkamFuZ28uZGIubW9kZWxzLmJhc2UKbW9kZWxfdW5waWNrbGUKcQNjc2tiYW5q\naS5iYW5qaS5tb2RlbHMKQmFuamkKcQRdY2RqYW5nby5kYi5tb2RlbHMuYmFzZQpzaW1wbGVfY2xh\nc3NfZmFjdG9yeQpxBYdScQZ9cQcoVQhtYWpvcl9pZHEIigEBVQZfc3RhdGVxCWNkamFuZ28uZGIu\nbW9kZWxzLmJhc2UKTW9kZWxTdGF0ZQpxCimBcQt9cQwoVQZhZGRpbmdxDYlVAmRicQ5VB2RlZmF1\nbHRxD3ViVQJpZHEQigEBVQdkYXRlX2lkcRGKAQFVBWJhbmppcRKKAQhVCmNvbGxlZ2VfaWRxE4oB\nAXVidS4=\n', '2013-01-13 23:42:49'),
('abf2e894536397274fc82ab4ee9ae736', 'ODQ0NzBjNWE5ZDI2YTA4ZTBhYWNhYjU0ZjJlYTRjNDRkNTBkNjU0MjqAAn1xAShVCnRlc3Rjb29r\naWVxAlUGd29ya2VkcQNVEWxvZ2luX2JhY2tfdG9fdXJscQRVAS91Lg==\n', '2013-04-14 01:00:38'),
('d820f580b84b2073363d6fafca22fdd9', 'ODQ0NzBjNWE5ZDI2YTA4ZTBhYWNhYjU0ZjJlYTRjNDRkNTBkNjU0MjqAAn1xAShVCnRlc3Rjb29r\naWVxAlUGd29ya2VkcQNVEWxvZ2luX2JhY2tfdG9fdXJscQRVAS91Lg==\n', '2013-04-14 01:01:08'),
('b73eefa31f12d83f6b9de3c2d603b6a4', 'Y2JjYjQ2NjAwZDc5MzFjZWU4N2RiYmQyYjJhMDZjYzM4NGU3Y2NhZTqAAn1xAShVEl9hdXRoX3Vz\nZXJfYmFja2VuZHECVSlkamFuZ28uY29udHJpYi5hdXRoLmJhY2tlbmRzLk1vZGVsQmFja2VuZHED\nVQ1fYXV0aF91c2VyX2lkcQSKAQhVEWxvZ2luX2JhY2tfdG9fdXJsVUVodHRwOi8vc2tiYW5qaS5z\naW5hYXBwLmNvbS9hY2NvdW50cy9sb2dpbi8/bmV4dD0vYWNjb3VudHMvam9pbl9iYW5qaS9xBXUu\n', '2013-01-14 03:10:59'),
('da4149eb19a036f9cf23854a8e47ec75', 'NGY5YzMzMzVkYjZhMTlmNTdmYzU5NmI3Zjk5MjNjOTdmZDUwMjJjMjqAAn1xAS4=\n', '2013-02-14 09:03:48'),
('48155ab0e0d03a43772e424597568c18', 'NjNmYzFjZjExMWFjODRlMjcxY2JhNmUzYzNjNTM5NmRjNDZjMjQ3NjqAAn1xAShVCnRlc3Rjb29r\naWVxAlUGd29ya2VkcQNVEWxvZ2luX2JhY2tfdG9fdXJscQRVG2h0dHA6Ly9za2JhbmppLnNpbmFh\ncHAuY29tL3EFdS4=\n', '2013-03-06 02:55:18'),
('159e632dd8193ed7459b2a700874e398', 'M2Q2MWY1M2IwYzU0ZGU1NTA0NDRkOTMxYjZiYWE1ZWI4NjRhN2UxNDqAAn1xAShVEl9hdXRoX3Vz\nZXJfYmFja2VuZFUpZGphbmdvLmNvbnRyaWIuYXV0aC5iYWNrZW5kcy5Nb2RlbEJhY2tlbmRVDV9h\ndXRoX3VzZXJfaWSKAQFVEWxvZ2luX2JhY2tfdG9fdXJsVSpodHRwOi8vc2tiYW5qaS5zaW5hYXBw\nLmNvbS9hY2NvdW50cy9sb2dpbi9VDWNob2ljZWRfYmFuamljZGphbmdvLmRiLm1vZGVscy5iYXNl\nCm1vZGVsX3VucGlja2xlCnECY3NrYmFuamkuYmFuamkubW9kZWxzCkJhbmppCnEDXWNkamFuZ28u\nZGIubW9kZWxzLmJhc2UKc2ltcGxlX2NsYXNzX2ZhY3RvcnkKcQSHUnEFfXEGKFUIbWFqb3JfaWRx\nB4oBAVUGX3N0YXRlcQhjZGphbmdvLmRiLm1vZGVscy5iYXNlCk1vZGVsU3RhdGUKcQkpgXEKfXEL\nKFUGYWRkaW5ncQyJVQJkYnENVQdkZWZhdWx0cQ51YlUCaWRxD4oBAVUHZGF0ZV9pZHEQigEBVQVi\nYW5qaXERigEIVQpjb2xsZWdlX2lkcRKKAQF1YnUu\n', '2013-03-08 11:40:24'),
('8033007307d1d6a6a913bfd7acbdbb2f', 'NGMyYjU3NDJmNWE5N2I2NDQwYTMwMzJlMTg1NDRkZTE0YzczMGY1MzqAAn1xAShVEWxvZ2luX2Jh\nY2tfdG9fdXJsVSpodHRwOi8vc2tiYW5qaS5zaW5hYXBwLmNvbS9hY2NvdW50cy9sb2dpbi9VDV9h\ndXRoX3VzZXJfaWSKAQFVEl9hdXRoX3VzZXJfYmFja2VuZFUpZGphbmdvLmNvbnRyaWIuYXV0aC5i\nYWNrZW5kcy5Nb2RlbEJhY2tlbmRVDWNob2ljZWRfYmFuamlxAmNkamFuZ28uZGIubW9kZWxzLmJh\nc2UKbW9kZWxfdW5waWNrbGUKcQNjc2tiYW5qaS5iYW5qaS5tb2RlbHMKQmFuamkKcQRdY2RqYW5n\nby5kYi5tb2RlbHMuYmFzZQpzaW1wbGVfY2xhc3NfZmFjdG9yeQpxBYdScQZ9cQcoVQhtYWpvcl9p\nZHEIigEBVQZfc3RhdGVxCWNkamFuZ28uZGIubW9kZWxzLmJhc2UKTW9kZWxTdGF0ZQpxCimBcQt9\ncQwoVQZhZGRpbmdxDYlVAmRicQ5VB2RlZmF1bHRxD3ViVQJpZHEQigEBVQdkYXRlX2lkcRGKAQFV\nBWJhbmppcRKKAQhVCmNvbGxlZ2VfaWRxE4oBAXVidS4=\n', '2013-04-14 00:57:53');

-- --------------------------------------------------------

--
-- 表的结构 `django_site`
--

CREATE TABLE IF NOT EXISTS `django_site` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `domain` varchar(100) NOT NULL,
  `name` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- 转存表中的数据 `django_site`
--

INSERT INTO `django_site` (`id`, `domain`, `name`) VALUES
(1, 'example.com', 'example.com');

-- --------------------------------------------------------

--
-- 表的结构 `major`
--

CREATE TABLE IF NOT EXISTS `major` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `college_id` int(11) NOT NULL,
  `major` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `major_6d2e0b0` (`college_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=3 ;

--
-- 转存表中的数据 `major`
--

INSERT INTO `major` (`id`, `college_id`, `major`) VALUES
(1, 1, '计算机科学与技术'),
(2, 1, '软件工程');

-- --------------------------------------------------------

--
-- 表的结构 `student`
--

CREATE TABLE IF NOT EXISTS `student` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(30) NOT NULL,
  `sex` varchar(20) NOT NULL,
  `student_number` varchar(30) NOT NULL,
  `banji_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `student_number` (`student_number`),
  KEY `student_5fedeacb` (`banji_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=100 ;

--
-- 转存表中的数据 `student`
--

INSERT INTO `student` (`id`, `name`, `sex`, `student_number`, `banji_id`) VALUES
(1, '﻿曹瑞', '男', '201001050801', 1),
(2, '丛君晓', '女', '201001050802', 1),
(3, '代贵常', '男', '201001050803', 1),
(4, '丁亦岭', '男', '201001050804', 1),
(5, '付联霞', '女', '201001050805', 1),
(6, '高峰', '男', '201001050806', 1),
(7, '高松', '男', '201001050807', 1),
(8, '谷学萍', '女', '201001050808', 1),
(9, '顾金山', '男', '201001050809', 1),
(10, '胡俊卿', '男', '201001050810', 1),
(11, '蓝艺鹏', '男', '201001050811', 1),
(12, '李广朋', '男', '201001050812', 1),
(13, '梁运杰', '男', '201001050813', 1),
(14, '刘超', '男', '201001050814', 1),
(15, '刘电台', '男', '201001050815', 1),
(16, '刘佳林', '男', '201001050816', 1),
(17, '刘少平', '男', '201001050817', 1),
(18, '孙凯', '男', '201001050818', 1),
(19, '孙业栋', '男', '201001050819', 1),
(20, '索慧明', '男', '201001050820', 1),
(21, '王明诚', '男', '201001050821', 1),
(22, '王珍珠', '女', '201001050822', 1),
(23, '王志超', '男', '201001050823', 1),
(24, '王铸', '男', '201001050824', 1),
(25, '杨江云', '女', '201001050825', 1),
(26, '杨洋', '男', '201001050826', 1),
(27, '尹晓晗', '女', '201001050827', 1),
(28, '于琦', '男', '201001050828', 1),
(29, '袁静静', '女', '201001050829', 1),
(30, '张彬', '男', '201001050830', 1),
(31, '张佃君', '男', '201001050831', 1),
(32, '张立啸', '男', '201001050832', 1),
(33, '张文涛', '男', '201001050833', 1),
(34, '郑毅', '男', '201001050835', 1),
(65, '曹鲁希', '男', '﻿201001050701', 2),
(66, '陈磊', '男', '201001050702', 2),
(67, '冯璨', '女', '201001050703', 2),
(68, '高阳阳', '男', '201001050704', 2),
(69, '宫若瑜', '男', '201001050705', 2),
(70, '郭光晓', '男', '201001050706', 2),
(71, '郝连敬', '男', '201001050707', 2),
(72, '郝宜丛', '男', '201001050708', 2),
(73, '何文涛', '男', '201001050709', 2),
(74, '姜超', '男', '201001050710', 2),
(75, '姜淋淋', '女', '201001050711', 2),
(76, '李江', '男', '201001050712', 2),
(77, '刘贝贝', '女', '201001050714', 2),
(78, '刘启', '男', '201001050715', 2),
(79, '刘一', '男', '201001050716', 2),
(80, '柳继强', '男', '201001050717', 2),
(81, '吕文秀', '女', '201001050718', 2),
(82, '马骁', '男', '201001050719', 2),
(83, '孟芳', '女', '201001050720', 2),
(84, '秦曦', '男', '201001050721', 2),
(85, '唐洪祥', '男', '201001050722', 2),
(86, '王超', '男', '201001050723', 2),
(87, '王顺禾', '男', '201001050724', 2),
(88, '魏子淏', '男', '201001050725', 2),
(89, '吴洪勇', '男', '201001050726', 2),
(90, '徐彬', '男', '201001050727', 2),
(91, '徐文浩', '男', '201001050728', 2),
(92, '薛宇非', '男', '201001050729', 2),
(93, '杨莉', '女', '201001050730', 2),
(94, '姚桂兰', '女', '201001050731', 2),
(95, '张成', '男', '201001050732', 2),
(96, '张延增', '男', '201001050733', 2),
(97, '张奕轩', '男', '201001050734', 2),
(98, '赵晓彬', '男', '201001050735', 2),
(99, '诸葛绪斌', '男', '201001050736', 2);

-- --------------------------------------------------------

--
-- 表的结构 `tucao`
--

CREATE TABLE IF NOT EXISTS `tucao` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `content` longtext NOT NULL,
  `date` varchar(30) NOT NULL,
  `user_id` int(11) NOT NULL,
  `banji_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `tucao_403f60f` (`user_id`),
  KEY `tucao_5fedeacb` (`banji_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=9 ;

--
-- 转存表中的数据 `tucao`
--

INSERT INTO `tucao` (`id`, `content`, `date`, `user_id`, `banji_id`) VALUES
(4, '实验', '2012-10-29 17:56:23', 1, 1),
(5, '再来', '2012-10-29 17:56:29', 1, 1),
(6, '应该加上时间\r\n', '2012-10-29 17:56:37', 1, 1),
(7, '我靠', '2012-10-30 22:17:27', 4, 1),
(8, 'hjh', '2012-12-05 13:19:47', 6, 8);

-- --------------------------------------------------------

--
-- 表的结构 `user_banji_relation`
--

CREATE TABLE IF NOT EXISTS `user_banji_relation` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `banji_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `user_banji_relation_403f60f` (`user_id`),
  KEY `user_banji_relation_5fedeacb` (`banji_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=11 ;

--
-- 转存表中的数据 `user_banji_relation`
--

INSERT INTO `user_banji_relation` (`id`, `user_id`, `banji_id`) VALUES
(5, 1, 1),
(6, 3, 1),
(7, 4, 1),
(8, 1, 8),
(9, 6, 8),
(10, 7, 1);
