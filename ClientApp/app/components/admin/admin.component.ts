import { Component, OnInit } from '@angular/core';

@Component({
    template: `
        <h1>Admin</h1>
        <chart type="pie" [data]="data"></chart>
    `
})

export class AdminComponent implements OnInit {
    data = {
        labels: ['PRODUITS DE LA MER', 'PRODUITS ASIATIQUES', 'AUTRES PRODUITS'],
        datasets: [
            {   
                type: 'doughnut',
                data: [ 500, 400, 450 ],
                backgroundColor: [
                    '#ff6384',
                    '#36a2eb',
                    '#cc65fe'
                ]
            }
        ]
    };

    constructor() { }

    ngOnInit() { }
}