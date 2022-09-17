import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { ProductItem } from './product.model'
import { HttpClient } from '@angular/common/http';
import { SaveOrder,Stock,StockResponse,Client,ClientResponse, BrokerResponse, Broker } from 'app/models/models';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  productItem: ProductItem[]=[];
  brokersArray: BrokerResponse[]=[];
  clientsArray: ClientResponse[]=[];
  brokerId:Number=0;
  clientId:Number=0;
  apiUrl:string='https://localhost:7089/api/';
  constructor(private http: HttpClient) {
    this.http.get(`${this.apiUrl}stock/list`)
    .subscribe((data:Stock)=>{
      data.$values.forEach((key, index) => {
let pItem=new ProductItem(key.id,key.name,key.price,
 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT5FpRKXeVbKWa1Wo75eOMva5FrE7QCREZgJj8iWNRZf9me2BcCRg');
    this.productItem.push(pItem);
      });
    });


    this.http.get(`${this.apiUrl}broker/list`)
    .subscribe((data:Broker)=>{
      data.$values.forEach((element)=>{
        let bItem=new BrokerResponse(element.$id,element.id,element.name);
        this.brokersArray.push(bItem);
      })
    });

    this.http.get(`${this.apiUrl}client/list`)
    .subscribe((data:Broker)=>{
      data.$values.forEach((element)=>{
        let cItem=new ClientResponse(element.$id,element.id,element.name);
        this.clientsArray.push(cItem);
      })
    });
  }
  @Output() cartUpdated = new EventEmitter<{
    productId: number,
    productName: string,
    productPrice: number,
    commission:number,
  }>();

  ngOnInit() {
  }

  onCartUpdated(event) {
    if(this.brokerId==0 && this.clientId==0){
      alert('Please select an option');
    }
    const id = event.target.getAttribute('id');
    const index = this.productItem.findIndex(elem => elem.id == id);
    let frac=0;
    if(this.brokerId&&this.brokerId!=0){
      frac=1/100;
      this.clientId=null;
    }
    if(this.clientId&&this.clientId!=0){
      frac=2/100;
      this.brokerId=null;
    }
    let data={
      "stockID":this.productItem[index].id,
      "commission":(this.productItem[index].price*frac),
      "price": this.productItem[index].price,
      "brokerId":this.brokerId,
      "personID":this.clientId
    };

    this.http.post(`${this.apiUrl}order`,data)
    .subscribe((result) => {
      if (result) {
        alert("Order created successfull.");
        }
    });
    this.cartUpdated.emit({
      productId: this.productItem[index].id,
      productName: this.productItem[index].name,
      productPrice: this.productItem[index].price,
      commission: (this.productItem[index].price*frac)
    });
}
onOptionsOfBrokerSelected(selectedIndex){
this.brokerId=this.brokersArray[selectedIndex-1].id;
}
onOptionsOfClientSelected(selectedIndex){
  this.clientId=this.clientsArray[selectedIndex-1].id;
  }
}


