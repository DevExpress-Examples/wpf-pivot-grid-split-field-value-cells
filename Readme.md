# How to split field value cells


<p>The following example demonstrates how to split field value cells.</p><p>In this example, the Grand Total column header is split into two cells: Price and Count. To do this, the CustomFieldValueCells event is handled, and the event parameter's Split method is used. Cells that should be split are identified by a predicate that returns true for those cells. The quantity, size and captions of newly created cells are specified by an array of cell definitions (the FieldValueSplitData objects).</p><br />


<br/>


