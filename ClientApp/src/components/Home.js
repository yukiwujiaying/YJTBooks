import React, { Component } from 'react';

export class Home extends Component {
    static displayName = Home.name;
    const products = [
        {name: 'prod1', price: 10.99 },
        {name: 'prod2', price: 11.99 },
    ]

  render () {
    return (
      <div>
            <h1>Hello, Tedy!</h1>
            <ul>
                {products.map(item => (
                    <li>{item.name} - {item.price}</li>
                ))}
}
            </ul>
        <p>Welcome to you next coding adventure</p>
      
        <p>To help you get started, we have also set up:</p>
            
      </div>
    );
  }
}
