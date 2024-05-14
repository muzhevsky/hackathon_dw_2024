import React, {useEffect, useState} from 'react';
import styles from './NavBar.module.css'
import {Col, Row} from "antd";
import {
    BankOutlined,
    CalendarOutlined,
    CarryOutOutlined,
    DesktopOutlined, FileOutlined,
    HomeOutlined,
    PieChartOutlined,
    ShopOutlined, StockOutlined, TeamOutlined, UserOutlined
} from "@ant-design/icons";
import type { MenuProps } from 'antd';
import { Breadcrumb, Layout, Menu, theme } from 'antd';
import { useLocation, useNavigate } from 'react-router-dom';
import { GLOBAL_EVENTS_PATH, HOME_PATH, RATING_PATH, SHOP_PATH } from '../../routing/RouterConstants';
const { Header, Content, Footer, Sider } = Layout;

type MenuItem = Required<MenuProps>['items'][number];


function getItem(
    label: React.ReactNode,
    key: React.Key,
    onClick: () => void,
    icon?: React.ReactNode,
    children?: MenuItem[],
   
): MenuItem {
    return {
        key,
        icon,
        children,
        label,
        onClick
    } as MenuItem;
}



interface NavBarProps {
    children:JSX.Element;
}

const NavBar: React.FC<NavBarProps> = ({children}) => {
    const locate = useLocation();
    const navigate = useNavigate();
    const [defaultKey,setDefaultKey] = useState<string[]>();
    const [collapsed, setCollapsed] = useState(false);

    const items: MenuItem[] = [
        getItem('Личный кабинет','1', () => navigate(HOME_PATH), <HomeOutlined/>),
        getItem('Мероприятия', '2', () => navigate(GLOBAL_EVENTS_PATH), <CalendarOutlined />),
        getItem('Рейтинг студентов', '3', () => navigate(RATING_PATH), <StockOutlined />),
        getItem('Магазин купонов', '4', () => navigate(SHOP_PATH), <BankOutlined />),
    ];

    useEffect(() => {
        console.log(locate.pathname);
        if(locate.pathname === GLOBAL_EVENTS_PATH) {
            console.warn('PATH IS GLOBAL EVENTS');
            setDefaultKey(["2"]);
            return;
        }
        if(locate.pathname === RATING_PATH) {
            console.warn('PATH IS GLOBAL RATINg');
            setDefaultKey(["3"]);
            return;
        }
        if(locate.pathname === SHOP_PATH) {
            setDefaultKey(["4"]);
            return;
        }
        if(locate.pathname === HOME_PATH) {
            setDefaultKey(["1"]);
            return;
        }
    }, [locate.pathname])

    return (
        <Layout style={{ minHeight: '100vh', marginRight: '10px'}}>
            <Sider collapsible collapsed={collapsed} onCollapse={(value) => setCollapsed(value)}>
                <div className="demo-logo-vertical">
                </div>
                <Menu className={styles.menu} theme="dark" selectedKeys={defaultKey} mode="inline" items={items} />
            </Sider>
            <Layout className={styles.padLayout}>
                {children}
            </Layout>
        </Layout>
    );
};

export default NavBar;