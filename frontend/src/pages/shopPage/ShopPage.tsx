import Ticket from "../../widgets/coupon/Ticket";
import styles from './ShopPage.module.css'

const ShopPage: React.FC = () => {
    return(
        <div>
            <h1>Магазин</h1>
            <div className={styles.WrapList}>
                <Ticket title={'фотосессия'} cost={500}/>
                <Ticket title={'закрытие лабораторной работы'} cost={1500}/>
                <Ticket title={'плюс балл к финальному проекту'} cost={1250}/>
                <Ticket title={'выбор фильма в кинотеатре'} cost={750}/>
                <Ticket title={'выбрать настолку на вечер'} cost={1000}/>

            </div>

        </div>
    )
}

export default ShopPage;